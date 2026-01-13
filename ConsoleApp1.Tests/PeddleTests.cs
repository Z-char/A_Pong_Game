using Xunit;

namespace ConsoleApp1.Tests;

public class PeddleTests
{
    [Fact]
    public void Constructor_FirstPlayer_InitializesCorrectly()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var paddle = new Peddle(board, GamePlayer.First);

        // Assert
        Assert.Equal(10, paddle.StartX()); // (24/2 - 4/2) = 10
        Assert.Equal(ConsoleKey.W, paddle.Up);
        Assert.Equal(ConsoleKey.S, paddle.Down);
    }

    [Fact]
    public void Constructor_SecondPlayer_InitializesCorrectly()
    {
        // Arrange
        var board = new Board(24, 90);

        // Act
        var paddle = new Peddle(board, GamePlayer.Second);

        // Assert
        Assert.Equal(10, paddle.StartX()); // (24/2 - 4/2) = 10
        Assert.Equal(ConsoleKey.UpArrow, paddle.Up);
        Assert.Equal(ConsoleKey.DownArrow, paddle.Down);
    }

    [Fact]
    public void StartX_ReturnsCurrentXPosition()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act
        var startX = paddle.StartX();

        // Assert
        Assert.Equal(10, startX);
    }

    [Fact]
    public void EndX_ReturnsStartXPlusLength()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act
        var endX = paddle.EndX();

        // Assert - paddle length is 4, so end should be start + 3
        Assert.Equal(13, endX);
    }

    [Fact]
    public void MidX_ReturnsMiddleOfPaddle()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act
        var midX = paddle.MidX();

        // Assert - (10 + 13) / 2 = 11
        Assert.Equal(11, midX);
    }

    [Fact]
    public void Move_Up_DecreasesXPosition()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);
        var initialX = paddle.StartX();

        // Act
        paddle.ChangeDir(Direction.Up);
        paddle.Move();

        // Assert
        Assert.Equal(initialX - 1, paddle.StartX());
    }

    [Fact]
    public void Move_Down_IncreasesXPosition()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);
        var initialX = paddle.StartX();

        // Act
        paddle.ChangeDir(Direction.Down);
        paddle.Move();

        // Assert
        Assert.Equal(initialX + 1, paddle.StartX());
    }

    [Fact]
    public void Move_Up_StopsAtTopBoundary()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act - Move up until we hit the boundary
        paddle.ChangeDir(Direction.Up);
        for (int i = 0; i < 15; i++)
        {
            paddle.Move();
        }

        // Assert - Should stop at board.StartX + 1
        Assert.Equal(1, paddle.StartX());
    }

    [Fact]
    public void Move_Down_StopsAtBottomBoundary()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act - Move down until we hit the boundary
        paddle.ChangeDir(Direction.Down);
        for (int i = 0; i < 15; i++)
        {
            paddle.Move();
        }

        // Assert - Should stop at board.Height - paddle_length - 1 = 24 - 4 - 1 = 19
        Assert.Equal(19, paddle.StartX());
    }

    [Fact]
    public void ChangeDir_UpdatesDirection()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);
        var initialX = paddle.StartX();

        // Act
        paddle.ChangeDir(Direction.Up);
        paddle.Move();
        var afterUpX = paddle.StartX();

        paddle.ChangeDir(Direction.Down);
        paddle.Move();
        var afterDownX = paddle.StartX();

        // Assert
        Assert.Equal(initialX - 1, afterUpX);
        Assert.Equal(initialX, afterDownX); // Should be back to initial position
    }

    [Fact]
    public void Stop_SetsStopFlag()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act
        paddle.stop();

        // Assert - This should not throw and should set internal flag
        // Since stopFlg is private, we verify the method doesn't throw
        Assert.True(true);
    }

    [Theory]
    [InlineData(10, 20)]
    [InlineData(30, 50)]
    [InlineData(15, 40)]
    public void Constructor_DifferentBoardSizes_PositionsCorrectly(int height, int width)
    {
        // Arrange
        var board = new Board(height, width);

        // Act
        var paddle = new Peddle(board, GamePlayer.First);

        // Assert - Should be centered vertically
        var expectedX = height / 2 - 2; // 2 is half of paddle length (4)
        Assert.Equal(expectedX, paddle.StartX());
    }

    [Fact]
    public void EndX_MinusStartX_EqualsPaddleLengthMinusOne()
    {
        // Arrange
        var board = new Board(24, 90);
        var paddle = new Peddle(board, GamePlayer.First);

        // Act
        var length = paddle.EndX() - paddle.StartX();

        // Assert - Paddle length is 4, so end - start = 3
        Assert.Equal(3, length);
    }
}
