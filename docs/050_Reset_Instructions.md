# Repository Reset Instructions

This ZIP is intended to replace the old Building Blocks content.

## Recommended safe reset workflow

From the existing repository:

```bash
git status
git checkout main
git pull
```

Create a safety tag and branch for the old state:

```bash
git tag legacy/building-blocks-import
git branch legacy/building-blocks
```

Then remove old content and copy the files from this ZIP into the repository root.

After copying:

```bash
git status
dotnet restore
dotnet build
dotnet test
```

If everything is fine:

```bash
git add .
git commit -m "Restart repository as SASD Toolbox for .NET"
```

For the first release:

```bash
git tag v0.1.0
git push
git push origin v0.1.0
```

## Important

Do not migrate old placeholder classes into the new structure.

Especially do not reintroduce:

- empty encryption classes;
- unfinished database helpers;
- classes named `File`;
- old .NET Framework 4.5.2 project files;
- old Building Blocks namespaces.
