# Exiled Dev References

A NuGet package containing all necessary DLLs for Exiled plugin development.

## Description

This package provides all the required DLL references for developing plugins for the Exiled framework. Instead of having to manually reference dozens of DLLs in your project, you can simply install this package to get all required dependencies.

## Installation

Install via NuGet Package Manager:
```
PM> Install-Package Exiled.Dev.References
```

Or via .NET CLI:
```
dotnet add package Exiled.Dev.References
```

## Usage

Once installed, all necessary DLLs will be available to your project. You can then start developing your Exiled plugin without needing to manually reference individual dependencies.

## Included References

This package includes all the necessary DLLs for Exiled development, including:
- Assembly-CSharp-Publicized.dll
- PluginAPI.dll
- Mirror.dll
- Unity assemblies
- System and framework libraries

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

Swishhyy