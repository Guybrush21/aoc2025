setup:
	dotnet restore
build:
	dotnet build
test:
	dotnet test 
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
