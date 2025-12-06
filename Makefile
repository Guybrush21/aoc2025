setup:
	dotnet restore
build:
	dotnet build
test:
	@echo "Running all tests (console output for failures is limited when running multiple tests)"
	@echo "To see detailed logs for a specific failing test, run: dotnet test --filter \"TestName\""
	@echo ""
	dotnet test
test-verbose:
	@echo "Running all tests with detailed console output (may be very verbose)"
	dotnet test --logger "console;verbosity=detailed"
test-simple:
	dotnet test --verbosity minimal
run:
	dotnet run --project ./AoC2025.Runner --
watch-test:
	dotnet watch test --project ./AoC2025.Test/AoC2025.Test.csproj
# Usage:
# make run DAY=1 PART=2
# Variables are optional; default day=1 runs both parts.
ifneq ($(DAY),)
	RUN_DAY=--day $(DAY)
endif
ifneq ($(PART),)
	RUN_PART=--part $(PART)
endif
run-%:
	dotnet run --project ./AoC2025.Runner -- $(RUN_DAY) $(RUN_PART)
