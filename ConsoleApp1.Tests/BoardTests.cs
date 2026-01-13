using Xunit;

namespace ConsoleApp1.Tests;

public class BoardTests
{
    [Fact]
    public void Constructor_WithHeightAndWidth_InitializesCorrectly()
    {
        // Arrange & Act
        var board = new Board(24, 90);

        // Assert
        Assert.Equal(24, board.Height);
        Assert.Equal(90, board.Width);
        Assert.Equal(12, board.HalfH);
        Assert.Equal(45, board.HalfW);
        Assert.Equal(0, board.StartX);
        Assert.Equal(0, board.StartY);
    }

    [Fact]
    public void Constructor_WithAllParameters_InitializesCorrectly()
    {
        // Arrange & Act
        var board = new Board(30, 100, 5, 10);

        // Assert
        Assert.Equal(30, board.Height);
        Assert.Equal(100, board.Width);
        Assert.Equal(15, board.HalfH);
        Assert.Equal(50, board.HalfW);
        Assert.Equal(5, board.StartX);
        Assert.Equal(10, board.StartY);
    }

    [Fact]
    public void GetElement_TopLeftCorner_ReturnsTopLeftChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(0, 0);

        // Assert
        Assert.Equal(CharacterUtilities.TopLeft, element);
    }

    [Fact]
    public void GetElement_TopRightCorner_ReturnsTopRightChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(0, 89);

        // Assert
        Assert.Equal(CharacterUtilities.TopRig, element);
    }

    [Fact]
    public void GetElement_BottomLeftCorner_ReturnsBottomLeftChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(23, 0);

        // Assert
        Assert.Equal(CharacterUtilities.BotLeft, element);
    }

    [Fact]
    public void GetElement_BottomRightCorner_ReturnsBottomRightChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(23, 89);

        // Assert
        Assert.Equal(CharacterUtilities.BotRig, element);
    }

    [Fact]
    public void GetElement_TopBorder_ReturnsHorizontalChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(0, 45);

        // Assert
        Assert.Equal(CharacterUtilities.Horiz, element);
    }

    [Fact]
    public void GetElement_BottomBorder_ReturnsHorizontalChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(23, 45);

        // Assert
        Assert.Equal(CharacterUtilities.Horiz, element);
    }

    [Fact]
    public void GetElement_LeftBorder_ReturnsVerticalChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(12, 0);

        // Assert
        Assert.Equal(CharacterUtilities.Verti, element);
    }

    [Fact]
    public void GetElement_RightBorder_ReturnsVerticalChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(12, 89);

        // Assert
        Assert.Equal(CharacterUtilities.Verti, element);
    }

    [Fact]
    public void GetElement_Center_ReturnsEmptyChar()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var element = board.GetElement(12, 45);

        // Assert
        Assert.Equal(CharacterUtilities.Empty, element);
    }

    [Fact]
    public void Get_ReturnsCorrectElement()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var topLeft = board.Get(0, 0);
        var center = board.Get(12, 45);

        // Assert
        Assert.Equal(CharacterUtilities.TopLeft, topLeft);
        Assert.Equal(CharacterUtilities.Empty, center);
    }

    [Theory]
    [InlineData(10, 20)]
    [InlineData(50, 100)]
    [InlineData(5, 10)]
    public void HalfValues_CalculatedCorrectly(int height, int width)
    {
        // Arrange & Act
        var board = new Board(height, width);

        // Assert
        Assert.Equal(height / 2, board.HalfH);
        Assert.Equal(width / 2, board.HalfW);
    }
}
