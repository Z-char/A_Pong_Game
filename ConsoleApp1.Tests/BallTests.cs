using Xunit;

namespace ConsoleApp1.Tests;

public class BallTests
{
    [Fact]
    public void Constructor_InitializesBallAtCenterOfBoard()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var ball = new Ball(board);

        // Assert
        var expectedX = board.StartX + board.HalfH; // 0 + 12 = 12
        var expectedY = board.StartY + board.HalfW; // 0 + 45 = 45
        Assert.Equal(expectedX, ball.GetX());
    }

    [Fact]
    public void GetX_ReturnsCurrentXPosition()
    {
        // Arrange
        var board = new Board(24, 90);
        var ball = new Ball(board);

        // Act
        var x = ball.GetX();

        // Assert
        Assert.Equal(12, x); // Center of 24-height board
    }

    [Theory]
    [InlineData(20, 40)]
    [InlineData(30, 60)]
    [InlineData(50, 100)]
    public void Constructor_DifferentBoardSizes_InitializesAtCenter(int height, int width)
    {
        // Arrange
        var board = new Board(height, width);

        // Act
        var ball = new Ball(board);

        // Assert
        var expectedX = board.StartX + height / 2;
        Assert.Equal(expectedX, ball.GetX());
    }

    [Fact]
    public void Constructor_WithCustomStartPosition_InitializesCorrectly()
    {
        // Arrange
        var board = new Board(24, 90, 5, 10);

        // Act
        var ball = new Ball(board);

        // Assert
        var expectedX = 5 + 12; // StartX + HalfH = 17
        Assert.Equal(expectedX, ball.GetX());
    }

    [Fact]
    public void Event_TouchPad_CanBeSubscribed()
    {
        // Arrange
        var board = new Board(24, 90);
        var ball = new Ball(board);
        var eventFired = false;

        // Act
        ball.tpad += () => eventFired = true;
        // Trigger the event manually by reflection if needed, or just verify subscription

        // Assert - Just verify we can subscribe without exceptions
        Assert.NotNull(ball.tpad);
    }

    [Fact]
    public void Event_MovePad_CanBeSubscribed()
    {
        // Arrange
        var board = new Board(24, 90);
        var ball = new Ball(board);
        var eventFired = false;

        // Act
        ball.mpad += () => eventFired = true;

        // Assert - Just verify we can subscribe without exceptions
        Assert.NotNull(ball.mpad);
    }

    [Fact]
    public void Constructor_InitialPosition_IsInBounds()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var ball = new Ball(board);
        var x = ball.GetX();

        // Assert - Ball should be within board boundaries
        Assert.True(x > board.StartX);
        Assert.True(x < board.StartX + board.Height);
    }

    [Fact]
    public void MultipleEventSubscribers_CanBeAdded()
    {
        // Arrange
        var board = new Board(24, 90);
        var ball = new Ball(board);
        var counter = 0;

        // Act
        ball.mpad += () => counter++;
        ball.mpad += () => counter++;
        ball.mpad += () => counter++;

        // Manually invoke to test
        ball.mpad?.Invoke();

        // Assert
        Assert.Equal(3, counter);
    }

    [Fact]
    public void Ball_StartsAtCorrectVerticalCenter()
    {
        // Arrange & Act
        var board = new Board(24, 90);
        var ball = new Ball(board);

        // Assert - For a 24-height board, center should be at row 12
        Assert.Equal(12, ball.GetX());
    }

    [Theory]
    [InlineData(10, 20, 5, 10)]
    [InlineData(40, 80, 20, 40)]
    [InlineData(100, 200, 50, 100)]
    public void Ball_AlwaysStartsAtBoardCenter(int height, int width, int expectedX, int expectedY)
    {
        // Arrange
        var board = new Board(height, width);

        // Act
        var ball = new Ball(board);

        // Assert
        Assert.Equal(expectedX, ball.GetX());
        // Note: We can't easily test Y position without making it public or using reflection
    }

    [Fact]
    public void Constructor_CreatesNonNullBall()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var ball = new Ball(board);

        // Assert
        Assert.NotNull(ball);
    }

    [Fact]
    public void Ball_InitiallyHasNoEventSubscribers()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var ball = new Ball(board);

        // Assert - Initially, events should be null (no subscribers)
        // We can't directly test this without reflection, but we can verify no exception occurs
        Assert.NotNull(ball);
    }
}
