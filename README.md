# Selenium C# NUnit Page Object Model Framework

This repository contains a starter Selenium automation framework using:
- C# (.NET)
- NUnit
- Selenium WebDriver
- Page Object Model design pattern

## Project structure

- `SeleniumNUnitPOM.sln` - solution file
- `src/SeleniumNUnitPOM/` - test project
  - `Drivers/` - WebDriver lifecycle management
  - `Pages/` - page objects
  - `Tests/` - test fixtures
  - `Utilities/` - reusable helpers

## Run tests

```bash
dotnet restore
dotnet test
```

> The sample test targets https://www.selenium.dev/ and validates page title and key elements.
