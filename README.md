# StackBlur

[![AppVeyor](https://img.shields.io/appveyor/ci/victoriqueko/stackblur/master.svg)](https://ci.appveyor.com/project/victoriqueko/stackblur/branch/master)
[![Codecov](https://img.shields.io/codecov/c/github/victoriqueko/stackblur/master.svg)](https://codecov.io/gh/victoriqueko/stackblur)
[![NuGet](https://img.shields.io/nuget/vpre/StackBlur.svg)](https://www.nuget.org/packages/StackBlur)

Fast and almost Gaussian blur implementation in C#.

> Algorithm created by Mario Klingemann (http://incubator.quasimondo.com/processing/fast_blur_deluxe.php).

## Getting Started

Use static method:

```C#
var bitmap = new Bitmap("image.bmp");
var radius = 10;

StackBlur.Process(bitmap, radius);

bitmap.Save("blurred image.bmp");
```

Or Extension:

```C#
var bitmap = new Bitmap("image.bmp");
var radius = 10;

bitmap.StackBlur(radius);

bitmap.Save("blurred image.bmp");
```

## Installation

Install as [NuGet Package](https://www.nuget.org/packages/StackBlur):

- Package manager

  ```PowerShell
  Install-Package StackBlur
  ```

- .NET CLI

  ```PowerShell
  dotnet add package StackBlur
  ```
