# Contributing

This project is currently in an early SASD preview phase.

Before adding new modules, please keep the first release goal in mind:

- small scope;
- readable code;
- clear XML documentation;
- unit tests for public behavior;
- no unfinished placeholder APIs.

## Coding style

- Prefer simple, readable code.
- Add XML comments to public APIs.
- Add inline comments where the code explains an educational or design decision.
- Keep modules separate so that each major area can become its own DLL and package.

## New module rule

Do not add unrelated functionality to an existing module.

Preferred pattern:

```text
src/Sasd.Toolbox.ModuleName/
tests/Sasd.Toolbox.ModuleName.Tests/
```
