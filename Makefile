## REFERENCES:
## (1) Passing environment variable with fallback value to Makefile:
##    https://stackoverflow.com/a/70772707/6366150
## (2) Export environment variables inside "make environment"
##		https://stackoverflow.com/a/49524393/6366150
## (3) Uppercase to lowercase and vice versa
##		https://community.unix.com/t/uppercase-to-lowercase-and-vice-versa/285278/6
## (4) How do I trim leading and trailing whitespace from each line of some output?
## 		https://unix.stackexchange.com/a/279222/233927
## (5) Pytest log levels:
##		https://docs.pytest.org/en/latest/how-to/logging.html
############################################################################

## (1) ## Allowed values: info | warn | error | debug
LOG_LEVEL ?= info
## (3) (4)
LOG_LEVEL :=$(shell echo '${LOG_LEVEL}'| tr '[:lower:]' '[:upper:]'| tr -d '[:blank:]')

## (1) ## Allowed values: true | false
BRUTEFORCE ?= false
## (3) (4)
BRUTEFORCE :=$(shell echo '${BRUTEFORCE}'| tr '[:lower:]' '[:upper:]'| tr -d '[:blank:]')

# DOCKER
BUILDKIT_PROGRESS=plain
DOCKER_COMPOSE=docker compose

.MAIN: test
.PHONY: all clean dependencies help list test
.EXPORT_ALL_VARIABLES: # (2)

RUNTIME_TOOL=dotnet
PACKAGE_TOOL=dotnet
VERBOSITY_LEVEL=normal

help: list
	@echo ""
	@echo "Note: create and activate the environment in your local shell type (example):"
	@echo "   python3 -m venv ./.venv"
	@echo "   source .venv/bin/activate"
	@echo "See: "
	@echo "   https://docs.python.org/3/library/venv.html#creating-virtual-environments"
	@echo "   https://docs.python.org/3/library/venv.html#how-venvs-work"

list:
	@LC_ALL=C $(MAKE) -pRrq -f $(lastword $(MAKEFILE_LIST)) : 2>/dev/null | awk -v RS= -F: '/^# File/,/^# Finished Make data base/ {if ($$1 !~ "^[#.]") {print $$1}}' | sort | egrep -v -e '^[^[:alnum:]]' -e '^$@$$'

env:
	@echo "################################################################################"
	@echo "## Environment: ################################################################"
	@echo "################################################################################"
	@printenv | grep -E "LOG_LEVEL|BRUTEFORCE|BUILDKIT_PROGRESS"
	@echo ""
	@echo "################################################################################"
	@echo "## Runtime: ####################################################################"
	@echo "################################################################################"
	@which $(PACKAGE_TOOL)
	@which $(RUNTIME_TOOL)
	@echo ""

install: dependencies

dependencies:
	@echo "################################################################################"
	@echo "## Dependencies: ###############################################################"
	@echo "################################################################################"
	${PACKAGE_TOOL} restore --verbosity ${VERBOSITY_LEVEL}
	@echo "################################################################################"

lint/markdown:
	markdownlint '**/*.md' --ignore node_modules && echo '✔  Your code looks good.'
lint/yaml:
	yamllint --stric . && echo '✔  Your code looks good.'

lint: lint/markdown lint/yaml test/styling test/static

test/static: dependencies

test/styling: dependencies
	${PACKAGE_TOOL} format --verify-no-changes --verbosity ${VERBOSITY_LEVEL}

format:
	${PACKAGE_TOOL} format --verbosity ${VERBOSITY_LEVEL}

build: env dependencies
	${PACKAGE_TOOL} build --verbosity ${VERBOSITY_LEVEL}

release: dependencies
	${PACKAGE_TOOL} publish --verbosity ${VERBOSITY_LEVEL}

test: build
	${PACKAGE_TOOL} test --verbosity ${VERBOSITY_LEVEL} \
		--collect:"Code Coverage" \
		--logger "console;verbosity=detailed"

coverage: dependencies test
	cat coverage-report/Summary.txt

coverage/html: dependencies test
	open coverage-report/index.html

outdated:

update:

upgrade:

clean:
	${PACKAGE_TOOL} clean --verbosity ${VERBOSITY_LEVEL}

	rm -vfr .mono/ || true
	rm -vfr coverage-report/ || true
	find ./src/ -path "*/TestResults/*" -type d -print -exec rm -vfr {} ';' || true
	find ./src/ -path "*/bin/*" -print -exec rm -vfr {} ';' || true
	find ./src/ -path "*/obj/*" -print -exec rm -vfr {} ';' || true
	find ./src/ -path "*/coverage*" -print -exec rm -vfr {} ';' || true
	find . -type d -print -empty -delete || true

compose/build: env
	${DOCKER_COMPOSE} --profile lint build
	${DOCKER_COMPOSE} --profile testing build
	${DOCKER_COMPOSE} --profile production build

compose/rebuild: env
	${DOCKER_COMPOSE} --profile lint build --no-cache
	${DOCKER_COMPOSE} --profile testing build --no-cache
	${DOCKER_COMPOSE} --profile production build --no-cache

compose/lint/markdown: compose/build
	${DOCKER_COMPOSE} --profile lint run --rm algorithm-exercises-csharp-lint make lint/markdown

compose/lint/yaml: compose/build
	${DOCKER_COMPOSE} --profile lint run --rm algorithm-exercises-csharp-lint make lint/yaml

compose/test/styling: compose/build
	${DOCKER_COMPOSE} --profile lint run --rm algorithm-exercises-csharp-lint make test/styling

compose/test/static: compose/build
	${DOCKER_COMPOSE} --profile lint run --rm algorithm-exercises-csharp-lint make test/static

compose/lint: compose/lint/markdown compose/lint/yaml compose/test/styling compose/test/static

compose/test: compose/build
	${DOCKER_COMPOSE} --profile testing run --rm algorithm-exercises-csharp-test make test

compose/run: compose/build
	${DOCKER_COMPOSE} --profile production run --rm algorithm-exercises-csharp make run

all: lint coverage

run:
	ls -alh
