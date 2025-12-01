# Advent of Code 2025 (C# / .NET)

Solutions and scaffolding for Advent of Code 2025 using C# and .NET. The repo is split into three projects:

- `AoC2025.Solver` — Library with the base solver and per‑day implementations
- `AoC2025.Runner` — Console app that runs a selected day and prints results
- `AoC2025.Test` — xUnit tests for day solutions

## Requirements

- .NET SDK 9.0
- A shell with `make` (optional; you can use `dotnet` commands directly)

## Quick Start

Using `make` (recommended):

```bash
make setup     # restore packages
make build     # build all projects
make test      # run tests
make run       # run day 1 (both parts)
# With variables:
make run DAY=1 PART=2
```

Using `dotnet` directly:

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project ./AoC2025.Runner -- --day 1 --part 2
```

## CLI

- `--day`, `-d` — Day number (default: 1)
- `--part`, `-p` — Part number (1 or 2). Omit to run both.

Examples:

```bash
# Run day 1 (both parts)
dotnet run --project ./AoC2025.Runner -- --day 1

# Run only part 2 of day 1
dotnet run --project ./AoC2025.Runner -- -d 1 -p 2
```

## Inputs

- Put puzzle input files under `./input/` with the file name equal to the day number.
  - Example for Day 1: `./input/1`
- Missing input files are reported with a clear error log, and the solver receives an empty input.

## Project Layout

- `AoC2025.Solver/SolverTemplate.cs` — Base class `SolverBase`
- `AoC2025.Solver/Solver-1.cs` — Implementation for Day 1
- `AoC2025.Solver/Solver.cs` — Registers day solvers and runs `Solve(day, part)`
- `AoC2025.Runner/Program.cs` — Console entry point + CLI options
- `AoC2025.Test/` — xUnit tests (see `Day1.cs`)
- `Makefile` — Convenience targets

## Running a Specific Day

- Default run executes Day 1.
- Select a day and part via CLI as shown above.
- If a requested day is not registered, a friendly error is logged.

## Adding a New Day

1. Copy `AoC2025.Solver/SolverTemplate.cs` to a new file `Solver-<N>.cs` and implement:
   - `public override string Part1()`
   - `public override string Part2()`
2. Register the new solver in `AoC2025.Solver/Solver.cs` constructor, e.g.:

```csharp
RegisterDay(N, day => new SolverN(day, LoadInput(day), logger));
```

3. Add tests under `AoC2025.Test/` (use `Day1.cs` as a template).
4. Place your puzzle input in `./input/N`.

## Testing

- Run all tests: `make test` or `dotnet test`
- Watch mode: `make watch-test`

## Logging

- Colorful, single-line console logging with timestamps via `Microsoft.Extensions.Logging.Console`.
- Categories distinguish Runner and Solver messages.
- Tests set logging to `Debug` for verbose output.

## Known Notes

- Input files are expected to be named without extension (e.g., `./input/1`).

## License

No license specified. If you intend to share or publish, consider adding a license file.
