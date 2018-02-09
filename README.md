# StackBlur

[![CircleCI](https://img.shields.io/circleci/project/github/victoriqueko/stackblur/master.svg?label=Linux)](https://circleci.com/gh/victoriqueko/stackblur/tree/master)
[![AppVeyor](https://img.shields.io/appveyor/ci/victoriqueko/stackblur/master.svg?label=Windows)](https://ci.appveyor.com/project/victoriqueko/stackblur/branch/master)
[![Codecov](https://img.shields.io/codecov/c/github/victoriqueko/stackblur/master.svg)](https://codecov.io/gh/victoriqueko/stackblur)
[![NuGet](https://img.shields.io/nuget/vpre/StackBlur.svg)](https://www.nuget.org/packages/StackBlur)

Fast and almost Gaussian blur implementation in C#.

> Algorithm created by Mario Klingemann (http://incubator.quasimondo.com/processing/fast_blur_deluxe.php).

## Getting Started

Use static method:

```
var bitmap = new Bitmap("image.bmp");
var radius = 10;

StackBlur.Process(bitmap, radius);

bitmap.Save("blurred image.bmp");
```

Or Extension:

```
var bitmap = new Bitmap("image.bmp");
var radius = 10;

bitmap.StackBlur(radius);

bitmap.Save("blurred image.bmp");
```

## Installation

Install as [NuGet Package](https://www.nuget.org/packages/StackBlur):

- Package manager

  ```
  Install-Package StackBlur
  ```

- .NET CLI

  ```
  dotnet add package StackBlur
  ```
