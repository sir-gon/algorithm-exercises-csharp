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
COPY ./algorithm-exercises-csharp.sln ${WORKDIR}/algorithm-exercises-csharp.sln
COPY ./algorithm-exercises-csharp/algorithm-exercises-csharp.csproj ${WORKDIR}/algorithm-exercises-csharp/algorithm-exercises-csharp.csproj
COPY ./algorithm-exercises-csharp-base/algorithm-exercises-csharp-base.csproj ${WORKDIR}/algorithm-exercises-csharp-base/algorithm-exercises-csharp-base.csproj
COPY ./algorithm-exercises-csharp-test/algorithm-exercises-csharp-test.csproj ${WORKDIR}/algorithm-exercises-csharp-test/algorithm-exercises-csharp-test.csproj

RUN make dependencies

###############################################################################
FROM base AS lint

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN apk add --update --no-cache make nodejs npm
RUN apk add --update --no-cache yamllint

RUN npm install -g --ignore-scripts markdownlint-cli

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
COPY ./algorithm-exercises-csharp ${WORKDIR}/algorithm-exercises-csharp
COPY ./algorithm-exercises-csharp-base ${WORKDIR}/algorithm-exercises-csharp-base
COPY ./algorithm-exercises-csharp-test ${WORKDIR}/algorithm-exercises-csharp-test
COPY ./algorithm-exercises-csharp.sln ${WORKDIR}/algorithm-exercises-csharp.sln

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

COPY ./algorithm-exercises-csharp ${WORKDIR}/algorithm-exercises-csharp
COPY ./algorithm-exercises-csharp-base ${WORKDIR}/algorithm-exercises-csharp-base
COPY ./algorithm-exercises-csharp-test ${WORKDIR}/algorithm-exercises-csharp-test
COPY ./algorithm-exercises-csharp.sln ${WORKDIR}/algorithm-exercises-csharp.sln

RUN make build
RUN ls -alh

# CMD []
###############################################################################
FROM development AS builder

RUN dotnet publish --self-contained --runtime linux-musl-x64
RUN ls -alh

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

ENV LOG_LEVEL=info
ENV BRUTEFORCE=false
ENV WORKDIR=/app
WORKDIR ${WORKDIR}

RUN adduser -D worker
RUN mkdir -p /app
RUN chown worker:worker /app

RUN apk add --update --no-cache make
COPY ./Makefile ${WORKDIR}/
COPY --from=builder /app/algorithm-exercises-csharp/bin/Release/net8.0/algorithm-exercises-csharp.dll ${WORKDIR}/
COPY --from=builder /app/algorithm-exercises-csharp/bin/Release/net8.0/algorithm-exercises-csharp.runtimeconfig.json ${WORKDIR}/

RUN ls -alh

USER worker
CMD ["make", "run"]

# checkov:skip= CKV_DOCKER_2: production image isn't a service process (yet)
