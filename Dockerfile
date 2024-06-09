###############################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0.301-alpine3.19-amd64 AS base

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

###############################################################################
FROM node:20.14.0-alpine3.20 AS mdlint

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

COPY ./docs ${WORKDIR}/docs
RUN apk add --update --no-cache make
RUN npm install -g markdownlint-cli

ENV WORKDIR=/app
WORKDIR ${WORKDIR}

COPY ./docs ${WORKDIR}/docs
RUN apk add --update --no-cache make
RUN npm install -g --ignore-scripts markdownlint-cli

###############################################################################
FROM base AS development

RUN apk add --update --no-cache make

###############################################################################
FROM development AS builder

COPY ./algorithm-exercises-csharp ${WORKDIR}/algorithm-exercises-csharp
COPY ./algorithm-exercises-csharp.sln ${WORKDIR}/algorithm-exercises-csharp.sln
COPY ./Makefile ${WORKDIR}/
RUN ls -alh

###############################################################################
### In testing stage, can't use USER, due permissions issue
## in github actions environment:
##
## https://docs.github.com/en/actions/creating-actions/dockerfile-support-for-github-actions
##
FROM builder AS testing

ENV LOG_LEVEL=INFO
ENV BRUTEFORCE=false

WORKDIR /app

COPY ./algorithm-exercises-csharp-test ${WORKDIR}/algorithm-exercises-csharp-test
RUN ls -alh

CMD ["dotnet", "test"]

###############################################################################
### In production stage
## in the production phase, "good practices" such as
## WORKSPACE and USER are maintained
##
FROM builder AS production

ENV LOG_LEVEL=INFO
ENV BRUTEFORCE=false

RUN adduser -D worker
RUN mkdir -p /app
RUN chown worker:worker /app

WORKDIR /app

COPY ./.pylintrc ${WORKDIR}/
COPY ./.coveragerc ${WORKDIR}/
RUN ls -alh

USER worker
CMD ["make", "test", "-e", "{DEBUG}"]
