ARG BUILDTIME_IMAGE=mcr.microsoft.com/dotnet/sdk:10.0.103-alpine3.22-amd64
ARG RUNTIME_IMAGE=mcr.microsoft.com/dotnet/runtime:10.0.3-alpine3.22-amd64

###############################################################################
FROM ${BUILDTIME_IMAGE} AS init

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN   apk add --update --no-cache make \
  &&  apk upgrade --no-cache # Avoid some CVE reports updating basic packages.

###############################################################################
FROM init AS base

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

COPY ./Makefile ${WORKDIR}/
COPY ./algorithm_exercises_csharp.sln ${WORKDIR}/algorithm_exercises_csharp.sln
COPY ./src/algorithm_exercises_csharp/algorithm_exercises_csharp.csproj ${WORKDIR}/src/algorithm_exercises_csharp/algorithm_exercises_csharp.csproj
COPY ./src/algorithm_exercises_csharp_base/algorithm_exercises_csharp_base.csproj ${WORKDIR}/src/algorithm_exercises_csharp_base/algorithm_exercises_csharp_base.csproj
COPY ./src/algorithm_exercises_csharp_test/algorithm_exercises_csharp_test.csproj ${WORKDIR}/src/algorithm_exercises_csharp_test/algorithm_exercises_csharp_test.csproj

RUN make dependencies

###############################################################################
FROM base AS lint

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN  apk add --update --no-cache make nodejs npm \
  && apk add --update --no-cache yamllint \
  && npm install -g --ignore-scripts markdownlint-cli@0.47.0

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
COPY ./src/algorithm_exercises_csharp ${WORKDIR}/src/algorithm_exercises_csharp
COPY ./src/algorithm_exercises_csharp_base ${WORKDIR}/src/algorithm_exercises_csharp_base
COPY ./src/algorithm_exercises_csharp_test ${WORKDIR}/src/algorithm_exercises_csharp_test

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
COPY ./src/algorithm_exercises_csharp ${WORKDIR}/src/algorithm_exercises_csharp
COPY ./src/algorithm_exercises_csharp_base ${WORKDIR}/src/algorithm_exercises_csharp_base
COPY ./src/algorithm_exercises_csharp_test ${WORKDIR}/src/algorithm_exercises_csharp_test

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
FROM ${RUNTIME_IMAGE} AS production

RUN   apk add --update --no-cache make \
  &&  apk upgrade --no-cache # Avoid some CVE reports updating basic packages.

ENV LOG_LEVEL=info
ENV BRUTEFORCE=false
ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN  adduser -D worker \
  && mkdir -p /app \
  && chown worker:worker /app

COPY ./Makefile ${WORKDIR}/
COPY --from=builder /app/src/algorithm_exercises_csharp/bin/Release/net8.0/algorithm_exercises_csharp.dll ${WORKDIR}/
COPY --from=builder /app/src/algorithm_exercises_csharp/bin/Release/net8.0/algorithm_exercises_csharp.runtimeconfig.json ${WORKDIR}/

RUN ls -alh

USER worker
CMD ["make", "run"]

# checkov:skip= CKV_DOCKER_2: production image isn't a service process (yet)
