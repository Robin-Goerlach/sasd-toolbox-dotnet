# SASD Toolbox for .NET

**SASD Toolbox for .NET** is a modern developer toolbox for small, reusable .NET libraries.

The project is inspired by the spirit of classic programming toolboxes from the Turbo Pascal era, but it is **not** a clone, continuation or replacement of any historical Borland product. The goal is to reinterpret the idea of practical, well-documented developer libraries for current .NET development.

This repository is a clean restart of the former Building Blocks experiment.

## Current release scope

Planned first release:

```text
SASD Toolbox for .NET v0.1.0 – Numerics Preview
```

Version `0.1.0` is intentionally small. It focuses on a clean structure, useful documentation, a working demo and tested numerical helper functions.

Included modules:

| Module | Project | Purpose |
|---|---|---|
| Core | `Sasd.Toolbox.Core` | Shared guard and validation helpers |
| Numerics | `Sasd.Toolbox.Numerics` | Basic statistics, interpolation and root finding |
| Demo | `Sasd.Toolbox.DemoConsole` | Small console demo showing how to use the toolbox |
| Tests | `Sasd.Toolbox.*.Tests` | Unit tests for the public API |

Not included in v0.1.0:

- database helpers;
- encryption helpers;
- graphics routines;
- editor components;
- game/demo source collections;
- C++ implementation.

Those areas may become separate modules later. They are deliberately not included until they can be implemented properly.

## Modular structure

The repository is designed so that every larger toolbox area can become its own DLL and, later, its own NuGet package.

```text
src/
  Sasd.Toolbox.Core/
  Sasd.Toolbox.Numerics/

samples/
  Sasd.Toolbox.DemoConsole/

tests/
  Sasd.Toolbox.Core.Tests/
  Sasd.Toolbox.Numerics.Tests/
```

This means a later application that only needs numerics should reference only:

```text
Sasd.Toolbox.Numerics
```

The numerics module depends on the small core module, but it does **not** pull in unrelated future modules such as graphics, editor or database functionality.

## Technology

- .NET 10
- C# 14
- SDK-style projects
- xUnit tests
- XML documentation enabled

Microsoft documents `net10.0` as the target framework moniker for .NET 10.

## Build

```bash
dotnet restore
dotnet build
```

## Test

```bash
dotnet test
```

## Run the demo

```bash
dotnet run --project samples/Sasd.Toolbox.DemoConsole/Sasd.Toolbox.DemoConsole.csproj
```

## Example

```csharp
using Sasd.Toolbox.Numerics;

double[] values = [2, 4, 4, 4, 5, 5, 7, 9];

double mean = Statistics.Mean(values);
double median = Statistics.Median(values);
double sampleVariance = Statistics.Variance(values, VarianceMode.Sample);

Console.WriteLine($"Mean: {mean}");
Console.WriteLine($"Median: {median}");
Console.WriteLine($"Sample variance: {sampleVariance}");
```

## Project status

Status: **early preview / clean restart**

This project is not yet a complete toolbox family. It is a carefully scoped first step toward a maintainable SASD toolbox ecosystem.

## Repository name

Recommended repository name:

```text
sasd-toolbox-dotnet
```

Recommended future organization location after the first usable release:

```text
SASDGMBH/sasd-toolbox-dotnet
```

## License

This project is released under the MIT License. See `LICENSE`.
