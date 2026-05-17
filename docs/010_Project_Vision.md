# Project Vision

## Working name

SASD Toolbox for .NET

## Purpose

SASD Toolbox for .NET is intended to become a family of small, practical, well-documented .NET libraries.

The project is inspired by the idea of classic programming toolboxes: useful routines, examples and building blocks that help developers learn, prototype and build maintainable software.

## Historical inspiration

The project is inspired by the spirit of classic developer toolboxes from the Turbo Pascal era.

It is not a clone, continuation or replacement of historical Borland products. The inspiration is conceptual:

- curated developer libraries;
- practical examples;
- clear documentation;
- reusable routines;
- educational value.

## SASD interpretation

The SASD version should be modern, modular and maintainable.

Instead of one large library, each major area should become its own DLL:

- `Sasd.Toolbox.Core`
- `Sasd.Toolbox.Numerics`
- `Sasd.Toolbox.Data`
- `Sasd.Toolbox.Editor`
- `Sasd.Toolbox.Graphics`
- `Sasd.Toolbox.Logic`
- `Sasd.Toolbox.Demos`

This keeps dependencies small and allows applications to reference only the modules they need.

## V0.1.0 goal

The first release should prove that the project can be:

- structured professionally;
- built with .NET 10;
- documented clearly;
- tested automatically;
- released in a small but credible form.

The first functional focus is Numerics.
