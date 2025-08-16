# API

This project contains the backend API for the DotTestKit-BoilerPlate.
It includes controllers, services, models, and unit tests using XUnit, Moq, and FluentAssertions.

## Development Server

To start the API locally, navigate to the API project folder:

```
cd API/DotTestKit.API
dotnet run
```

## Code Structure

Controllers/ – API controllers for handling HTTP requests.

Services/ – Business logic services.

Models/ – Data models for the API.

DotTestKit.API.csproj – Main API project file.

DotTestKit.API.Tests/ – Unit tests for controllers and services.

## Building

To build the API project:

```
cd API/DotTestKit.API
dotnet build
```

## Running Unit Tests

Navigate to the test project:

```
cd API/DotTestKit.API.Tests
dotnet test
```

This runs all XUnit tests for controllers and services.

Tests use Moq for mocking dependencies and FluentAssertions for readable assertions.

## Collecting Code Coverage

Run the tests with code coverage:

```
dotnet test --collect:"XPlat Code Coverage" --results-directory TestResults
```

Coverage files are generated at:

API/DotTestKit.API.Tests/TestResults/<GUID>/coverage.cobertura.xml

## Generating HTML Coverage Report

Use ReportGenerator to generate an HTML report:

```
reportgenerator -reports:"TestResults/<GUID>/coverage.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html
```

Open the report:

API/DotTestKit.API.Tests/CoverageReport/index.html

## Code Scaffolding

To add new functionality:

Create a new model in Models/.

Add business logic in Services/.

Add endpoints in Controllers/.

Add corresponding unit tests in DotTestKit.API.Tests/.
