# Release Notes - v0.1.0

## SASD Toolbox for .NET v0.1.0 - Numerics Preview

This is the first clean preview release of SASD Toolbox for .NET.

It replaces the former Building Blocks experiment with a modern .NET 10 solution structure.

## Highlights

- Clean .NET 10 solution
- Modular class library structure
- Separate Core and Numerics DLLs
- Demo console application
- xUnit tests
- XML documentation comments
- Small but working numerical feature set

## Included APIs

### Core

- `Guard.NotNull`
- `Guard.NotNullOrEmpty`
- `Guard.InRange`
- `Guard.Finite`

### Numerics

- `Statistics.Mean`
- `Statistics.Median`
- `Statistics.Variance`
- `Interpolation.Linear`
- `BisectionRootFinder.FindRoot`

## Known limitations

This is not yet a complete toolbox family.

The following areas are intentionally not included:

- database helpers;
- encryption helpers;
- graphics routines;
- editor routines;
- games/demos;
- C++ implementation.

## Recommended release tag

```text
v0.1.0
```
