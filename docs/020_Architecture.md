# Architecture

## Architectural decision

The repository uses a modular multi-project structure.

Each toolbox area is represented by its own class library project. This is important because the future toolbox family may become large, and consumers should not be forced to reference unrelated functionality.

## Current modules

### Sasd.Toolbox.Core

Contains small shared helper APIs.

Current responsibility:

- guard and validation methods.

This project should remain small and dependency-free.

### Sasd.Toolbox.Numerics

Contains numerical helper APIs.

Current responsibility:

- basic statistics;
- linear interpolation;
- bisection root finding.

The numerics project references `Sasd.Toolbox.Core`.

### Sasd.Toolbox.DemoConsole

Contains a simple console application that demonstrates the current APIs.

The demo is not a library and should not be packaged.

### Test projects

Each module should have its own test project.

Current test projects:

- `Sasd.Toolbox.Core.Tests`
- `Sasd.Toolbox.Numerics.Tests`

## Future module strategy

Future modules should not be added to existing projects just because that is quicker.

Preferred pattern:

```text
src/Sasd.Toolbox.NewModule/
tests/Sasd.Toolbox.NewModule.Tests/
```

This keeps the repository understandable and helps later NuGet packaging.
