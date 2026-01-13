using Xunit;

namespace ConsoleApp1.Tests;

public class CharacterUtilitiesTests
{
    [Fact]
    public void Empty_IsSpaceCharacter()
    {
        // Assert
        Assert.Equal(' ', CharacterUtilities.Empty);
    }

    [Fact]
    public void Ball_IsLowercaseO()
    {
        // Assert
        Assert.Equal('o', CharacterUtilities.Ball);
    }

    [Fact]
    public void Cursor_IsBlackSquare()
    {
        // Assert
        Assert.Equal('■', CharacterUtilities.Cursor);
    }

    [Fact]
    public void Player_IsFilledBlock()
    {
        // Assert
        Assert.Equal('█', CharacterUtilities.Player);
    }

    [Fact]
    public void Horiz_IsDoubleHorizontalLine()
    {
        // Assert
        Assert.Equal('═', CharacterUtilities.Horiz);
    }

    [Fact]
    public void Verti_IsVerticalLine()
    {
        // Assert
        Assert.Equal('║', CharacterUtilities.Verti);
    }

    [Fact]
    public void TopLeft_IsTopLeftCorner()
    {
        // Assert
        Assert.Equal('╔', CharacterUtilities.TopLeft);
    }

    [Fact]
    public void TopRig_IsTopRightCorner()
    {
        // Assert
        Assert.Equal('╗', CharacterUtilities.TopRig);
    }

    [Fact]
    public void BotLeft_IsBottomLeftCorner()
    {
        // Assert
        Assert.Equal('╚', CharacterUtilities.BotLeft);
    }

    [Fact]
    public void BotRig_IsBottomRightCorner()
    {
        // Assert
        Assert.Equal('╝', CharacterUtilities.BotRig);
    }

    [Fact]
    public void AllCharacters_AreUnique()
    {
        // Arrange
        var characters = new[]
        {
            CharacterUtilities.Empty,
            CharacterUtilities.Ball,
            CharacterUtilities.Cursor,
            CharacterUtilities.Player,
            CharacterUtilities.Horiz,
            CharacterUtilities.Verti,
            CharacterUtilities.TopLeft,
            CharacterUtilities.TopRig,
            CharacterUtilities.BotLeft,
            CharacterUtilities.BotRig
        };

        // Act
        var uniqueCharacters = characters.Distinct().ToArray();

        // Assert
        Assert.Equal(characters.Length, uniqueCharacters.Length);
    }
}
