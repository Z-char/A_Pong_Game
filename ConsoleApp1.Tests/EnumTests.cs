using Xunit;

namespace ConsoleApp1.Tests;

public class EnumTests
{
    [Fact]
    public void GamePlayer_HasCorrectValues()
    {
        // Assert
        Assert.Equal(0, (int)GamePlayer.Auto);
        Assert.Equal(1, (int)GamePlayer.First);
        Assert.Equal(2, (int)GamePlayer.Second);
    }

    [Fact]
    public void GamePlayer_ContainsThreeValues()
    {
        // Arrange
        var values = Enum.GetValues(typeof(GamePlayer));

        // Assert
        Assert.Equal(3, values.Length);
    }

    [Fact]
    public void Direction_HasCorrectFlagValues()
    {
        // Assert
        Assert.Equal(1, (int)Direction.Up);
        Assert.Equal(2, (int)Direction.Down);
        Assert.Equal(4, (int)Direction.Left);
        Assert.Equal(8, (int)Direction.Right);
        Assert.Equal(16, (int)Direction.Stop);
    }

    [Fact]
    public void Direction_ContainsFiveValues()
    {
        // Arrange
        var values = Enum.GetValues(typeof(Direction));

        // Assert
        Assert.Equal(5, values.Length);
    }

    [Fact]
    public void Direction_CanBeCombinedWithFlags()
    {
        // Arrange & Act
        var upRight = Direction.Up | Direction.Right;
        var downLeft = Direction.Down | Direction.Left;

        // Assert
        Assert.Equal(9, (int)upRight); // 1 + 8 = 9
        Assert.Equal(6, (int)downLeft); // 2 + 4 = 6
    }

    [Fact]
    public void Direction_FlagCombination_CanBeDetected()
    {
        // Arrange
        var upRight = Direction.Up | Direction.Right;

        // Act
        var hasUp = ((int)upRight & (int)Direction.Up) != 0;
        var hasRight = ((int)upRight & (int)Direction.Right) != 0;
        var hasDown = ((int)upRight & (int)Direction.Down) != 0;

        // Assert
        Assert.True(hasUp);
        Assert.True(hasRight);
        Assert.False(hasDown);
    }

    [Theory]
    [InlineData(Direction.Up, 1)]
    [InlineData(Direction.Down, 2)]
    [InlineData(Direction.Left, 4)]
    [InlineData(Direction.Right, 8)]
    [InlineData(Direction.Stop, 16)]
    public void Direction_EachValueHasCorrectIntegerValue(Direction direction, int expectedValue)
    {
        // Assert
        Assert.Equal(expectedValue, (int)direction);
    }

    [Theory]
    [InlineData(GamePlayer.Auto, "Auto")]
    [InlineData(GamePlayer.First, "First")]
    [InlineData(GamePlayer.Second, "Second")]
    public void GamePlayer_HasCorrectNames(GamePlayer player, string expectedName)
    {
        // Act
        var actualName = player.ToString();

        // Assert
        Assert.Equal(expectedName, actualName);
    }
}
