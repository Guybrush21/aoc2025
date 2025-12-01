# Advent of Code 2025 (C# / .NET)

Solutions and scaffolding for Advent of Code 2025 using C# and .NET. The repo is split into three projects:

- `AoC2025.Solver` — Library with the base solver and per‑day implementations
- `AoC2025.Runner` — Console app that runs a selected day and prints results
- `AoC2025.Test` — xUnit tests for day solutions

## Requirements

- .NET SDK 9.0 (for runner and tests)
  - The solver library currently targets `net8.0`. Building with .NET 9 SDK works if the .NET 8 targeting pack is installed. If your machine lacks it, install the .NET 8 SDK as well.
- A shell with `make` (optional; you can use `dotnet` commands directly)

## Quick Start

Using `make` (recommended):

```bash
make setup     # restore packages
make build     # build all projects
make test      # run tests
make run       # run the console for the current day
```

Using `dotnet` directly:

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project ./AoC2025.Runner
```

## Inputs

- Put your puzzle input files under `./input/` with the file name equal to the day number.
  - Example for Day 1: `./input/1`
- Day implementations read their input with `File.ReadAllLines($"./input/{day}")`.
- The Day 1 solver expects lines containing two integers separated by three spaces (the AoC 2024-style sample uses triple spaces):

```
3   4
4   3
2   5
1   3
3   9
3   3
```

## Project Layout

- `AoC2025.Solver/SolverTemplate.cs` — Base class `SolverBase` that all days inherit
- `AoC2025.Solver/Solver-1.cs` — Implementation for Day 1
- `AoC2025.Solver/Solver.cs` — Registers available day solvers and exposes `Solve(day)`
- `AoC2025.Runner/Program.cs` — Console entry point; creates a logger and invokes the solver
- `AoC2025.Test/` — xUnit tests (see `Day1.cs` for a sample)
- `Makefile` — Convenience targets for common workflows

## Running a Specific Day

The runner invokes `new Solver(logger).Solve()`.

- Currently, `Solve` has a default parameter of `day = 2`, while only Day 1 is registered. If you run the console as-is, it will throw because there is no Day 2 yet.
- Until more days are added, either:
  1. Change the default to `day = 1` in `AoC2025.Solver/Solver.cs`, or
  2. Pass a day explicitly from the runner, e.g. modify `Program.cs` to call `solver.Solve(1);`

Once aligned, run:

```bash
dotnet run --project ./AoC2025.Runner
```

## Adding a New Day

1. Copy `AoC2025.Solver/SolverTemplate.cs` to a new file `Solver-<N>.cs` and implement:
   - `public override string Part1()`
   - `public override string Part2()`
2. Register the new solver in `AoC2025.Solver/Solver.cs` constructor, e.g.:

```csharp
this.solvers.Add(new SolverN(N, File.ReadAllLines($"./input/{N}"), logger));
```

3. Add tests under `AoC2025.Test/` (use `Day1.cs` as a template):

```csharp
[Fact]
public void DayN_Part1_Sample() {
    var input = "..."; // sample input
    var solver = new SolverN(N, input.Split(Environment.NewLine), logger);
    Assert.Equal("expected", solver.Part1());
}
```

4. Place your puzzle input in `./input/N`.

## Testing

- Run all tests: `make test` or `dotnet test`
- Watch mode: `make watch-test`

## Logging

- The runner uses `Microsoft.Extensions.Logging.Console` with Information level by default.
- Tests configure logging at `Debug` level for more verbose output.
- There is an `appsettings.json` containing an `NLog` section, but NLog is not currently wired into the runner; only the console logger is active.

## Make Targets

- `setup` — `dotnet restore`
- `build` — `dotnet build`
- `test` — `dotnet test`
- `run` — `dotnet run --project ./AoC2025.Runner`
- `watch-test` — `dotnet watch test --project ./AoC2025.Test/AoC2025.Test.csproj`

## Known Quirks

- `Solver.Solve` defaults to `day = 2` while only Day 1 is registered. Adjust the default or the call site until Day 2 is implemented.
- Input files are expected to be named without extension (e.g., `./input/1`).

## License

No license specified. If you intend to share or publish, consider adding a license file.
