setup:
	dotnet restore
build:
	dotnet build
test:
	dotnet test 
run:
	dotnet run --project ./AoC2025.Runner
watch-test:
	dotnet watch test --project ./AoC2025.Test/AoC2025.Test.csproj
