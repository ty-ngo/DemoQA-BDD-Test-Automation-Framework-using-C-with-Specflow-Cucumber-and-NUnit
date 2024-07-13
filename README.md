# DemoQA BDD Automation Test Project

## Overview
This project is an automation test suite for the DemoQA, developed using .NET 8 with C# as the primary programming language, and NUnit 3 for testing.

## Project Structure
The solution comprises three projects:

1. **Core**: Contains utilities for API and WebDriver interaction and configuration file management.
2. **DemoQA.Services**: Contains request and response models, as well as `UserServices` and `BookServices` for sending API requests.
3. **DemoQA.BDDTesting**: Contains the features and step definitions for test cases about `Student` and `Books`, test data, and configuration settings (`appsettings.json`).

## Development Tools
The project is set up using Visual Studio Code.

## Configuration File
The primary configuration file for this project is `appsettings.json`, which contains the application URL

## Running Tests
Before running the test, you must log into https://demoqa.com/books to create new user and get the username, password, userId. Then, paste it into the file account.json in the `DemoQA.BDDTesting/TestData/Account` folder.
### Using Visual Studio Code
- Utilize the Test Explorer to select and run tests.

### Using Command Line
1. Restore all dependency packages:
   ```sh
   dotnet restore
   ```
2. Build the project:
   ```sh
   dotnet build
   ```
3. Run all tests:
   ```sh
   dotnet test
   ```
4. Run specific tests based on category:
   ```sh
   dotnet test --filter Category=RegisterStudent
   ```
   (Replace `RegisterStudent` with the desired test category: `SearchBook` or `DeleteBook`)