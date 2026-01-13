# ConsoleApp1 Unit Tests

This directory contains comprehensive unit tests for the Pong Game project using xUnit.

## Test Coverage

The test suite covers the following components:

### 1. **BoardTests.cs** (14 tests)
Tests for the game board functionality:
- Board construction with different parameters
- Corner character rendering (TopLeft, TopRight, BottomLeft, BottomRight)
- Border character rendering (Horizontal, Vertical)
- Center/empty space rendering
- Half-width and half-height calculations
- Element retrieval from the board field

### 2. **CharacterUtilitiesTests.cs** (11 tests)
Tests for character constants:
- Validates all game characters (Ball, Player, Cursor, Empty, Borders)
- Ensures all characters are unique
- Verifies correct Unicode box-drawing characters

### 3. **EnumTests.cs** (8 tests)
Tests for game enumerations:
- **GamePlayer enum**: Auto, First, Second values
- **Direction enum**: Flag-based direction values (Up, Down, Left, Right, Stop)
- Direction combination tests (bitwise operations)
- Enum name validation

### 4. **PeddleTests.cs** (14 tests)
Tests for paddle (player racket) functionality:
- Paddle initialization for Player 1 and Player 2
- Position tracking (StartX, EndX, MidX)
- Movement (Up/Down direction)
- Boundary collision detection (top and bottom walls)
- Direction changes
- Paddle length validation (4 characters)
- Different board size compatibility

### 5. **BallTests.cs** (12 tests)
Tests for ball physics and behavior:
- Ball initialization at board center
- Position tracking (GetX method)
- Event system (tpad, mpad delegates)
- Different board size compatibility
- Boundary position validation
- Multiple event subscriber support

## Test Statistics

- **Total Test Files**: 5
- **Total Test Methods**: 59
- **Test Framework**: xUnit 2.4.2
- **Target Framework**: .NET 6.0

## Running the Tests

### Using .NET CLI

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity detailed

# Run tests and generate coverage report
dotnet test --collect:"XPlat Code Coverage"

# Run specific test file
dotnet test --filter "FullyQualifiedName~BoardTests"

# Run specific test method
dotnet test --filter "FullyQualifiedName~BoardTests.Constructor_WithHeightAndWidth_InitializesCorrectly"
```

### Using Visual Studio

1. Open `ConsoleApp1.sln` in Visual Studio
2. Open **Test Explorer** (Test → Test Explorer)
3. Click **Run All** to execute all tests
4. Right-click individual tests to run them separately

### Using Visual Studio Code

1. Install the **.NET Core Test Explorer** extension
2. Tests will appear in the Test Explorer sidebar
3. Click the play button to run tests

### Using Rider

1. Open the solution in JetBrains Rider
2. Tests will automatically appear in the Unit Tests window
3. Use Ctrl+T, L to run all tests

## Test Output Example

```
Starting test execution, please wait...
A total of 59 tests ran in 1.2 seconds
  Passed: 59
  Failed: 0
  Skipped: 0
```

## Continuous Integration

Tests are automatically run on every push via GitHub Actions. See `.github/workflows/dotnet-desktop.yml` for CI/CD configuration.

## Adding New Tests

When adding new tests:

1. Create a new file named `<ClassName>Tests.cs`
2. Use the `ConsoleApp1.Tests` namespace
3. Follow the Arrange-Act-Assert pattern
4. Use descriptive test method names: `MethodName_Scenario_ExpectedBehavior`
5. Use `[Fact]` for single test cases
6. Use `[Theory]` with `[InlineData]` for parameterized tests

### Example Test

```csharp
[Fact]
public void Board_Constructor_InitializesCorrectly()
{
    // Arrange
    var height = 24;
    var width = 90;

    // Act
    var board = new Board(height, width);

    // Assert
    Assert.Equal(24, board.Height);
    Assert.Equal(90, board.Width);
}
```

## Test Coverage Goals

Current coverage:
- ✅ Board class: 100%
- ✅ CharacterUtilities: 100%
- ✅ Enums: 100%
- ✅ Peddle (Paddle) class: ~80% (threading/UI excluded)
- ✅ Ball class: ~60% (threading/UI excluded)
- ❌ GameManager: Not tested (integration component)
- ❌ MainMenu: Not tested (UI component)
- ❌ InputScanner: Not tested (threading/IO component)
- ❌ UIUtilities: Not tested (Console IO component)

## Known Limitations

Some components are difficult to unit test due to:
- Direct Console I/O operations (UIUtilities, MainMenu)
- Threading without dependency injection (Ball.start, Peddle.start, InputScanner)
- Tight coupling with Console API

Future improvements could include:
- Abstracting Console operations behind interfaces
- Dependency injection for better testability
- Integration tests for full game flow
- Mocking Console operations
