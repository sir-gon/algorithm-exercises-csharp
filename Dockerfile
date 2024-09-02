###############################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0.401-alpine3.19-amd64 AS init

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN apk add --update --no-cache make

###############################################################################
FROM init AS base

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

COPY ./Makefile ${WORKDIR}/
COPY ./algorithm_exercises_csharp.sln ${WORKDIR}/algorithm_exercises_csharp.sln
COPY ./algorithm_exercises_csharp/algorithm_exercises_csharp.csproj ${WORKDIR}/algorithm_exercises_csharp/algorithm_exercises_csharp.csproj
COPY ./algorithm-exercises-csharp-base/algorithm-exercises-csharp-base.csproj ${WORKDIR}/algorithm-exercises-csharp-base/algorithm-exercises-csharp-base.csproj
COPY ./algorithm-exercises-csharp-test/algorithm-exercises-csharp-test.csproj ${WORKDIR}/algorithm-exercises-csharp-test/algorithm-exercises-csharp-test.csproj

RUN make dependencies

###############################################################################
FROM base AS lint

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN  apk add --update --no-cache make nodejs npm \
  && apk add --update --no-cache yamllint \
  && npm install -g --ignore-scripts markdownlint-cli

# [!TIP] Use a bind-mount to "/app" to override following "copys"
# for lint and test against "current" sources in this stage

# YAML sources
COPY ./.github ${WORKDIR}/
COPY ./compose.yaml ${WORKDIR}/

# Markdown sources
COPY ./docs ${WORKDIR}/
COPY ./README.md ${WORKDIR}/
COPY ./LICENSE.md ${WORKDIR}/
COPY ./CODE_OF_CONDUCT.md ${WORKDIR}/

# Code source
COPY ./algorithm_exercises_csharp.sln ${WORKDIR}/algorithm_exercises_csharp.sln
COPY ./algorithm_exercises_csharp ${WORKDIR}/algorithm_exercises_csharp
COPY ./algorithm-exercises-csharp-base ${WORKDIR}/algorithm-exercises-csharp-base
COPY ./algorithm-exercises-csharp-test ${WORKDIR}/algorithm-exercises-csharp-test

# code linting conf
COPY ./.editorconfig ${WORKDIR}/

# markdownlint conf
COPY ./.markdownlint.yaml ${WORKDIR}/

# yamllint conf
COPY ./.yamllint ${WORKDIR}/
COPY ./.yamlignore ${WORKDIR}/

CMD ["make", "lint"]

###############################################################################
FROM base AS development

COPY ./algorithm_exercises_csharp.sln ${WORKDIR}/algorithm_exercises_csharp.sln
COPY ./algorithm_exercises_csharp ${WORKDIR}/algorithm_exercises_csharp
COPY ./algorithm-exercises-csharp-base ${WORKDIR}/algorithm-exercises-csharp-base
COPY ./algorithm-exercises-csharp-test ${WORKDIR}/algorithm-exercises-csharp-test

RUN  make build \
  && ls -alh

# CMD []
###############################################################################
FROM development AS builder

RUN  dotnet publish --self-contained --runtime linux-musl-x64 \
  && ls -alh

CMD ["ls", "-alh"]

###############################################################################
### In testing stage, can't use USER, due permissions issue
## in github actions environment:
##
## https://docs.github.com/en/actions/creating-actions/dockerfile-support-for-github-actions
##
FROM development AS testing

ENV LOG_LEVEL=INFO
ENV BRUTEFORCE=false

WORKDIR /app

RUN ls -alh

CMD ["make", "test"]

###############################################################################
### In production stage
## in the production phase, "good practices" such as
## WORKDIR and USER are maintained
##
FROM mcr.microsoft.com/dotnet/runtime:8.0.8-alpine3.19-amd64 AS production

RUN apk add --update --no-cache make

ENV LOG_LEVEL=info
ENV BRUTEFORCE=false
ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN  adduser -D worker \
  && mkdir -p /app \
  && chown worker:worker /app

COPY ./Makefile ${WORKDIR}/
COPY --from=builder /app/algorithm_exercises_csharp/bin/Release/net8.0/algorithm_exercises_csharp.dll ${WORKDIR}/
COPY --from=builder /app/algorithm_exercises_csharp/bin/Release/net8.0/algorithm_exercises_csharp.runtimeconfig.json ${WORKDIR}/

RUN ls -alh

USER worker
CMD ["make", "run"]

# checkov:skip= CKV_DOCKER_2: production image isn't a service process (yet)
