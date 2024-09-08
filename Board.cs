using System.Security.Cryptography;

internal class Board
{
	public readonly int StartX = 0;
    public readonly int StartY = 0;
    public readonly int Height = 24;
	public readonly int Width = 90;
	public readonly int HalfW;
    public readonly int HalfH;
    private char[,] Field;

	public Board(int height, int width)
	{
		Height = height;
		Width = width;
		HalfH = Height / 2;
		HalfW = Width / 2;
        Field = new char[Height, Width];
        resize();
	}
	public Board(int height, int width, int Sx, int Sy)
	{
        Height = height;
        Width = width;
        HalfH = Height / 2;
        HalfW = Width / 2;
        StartX = Sx;
		StartY = Sy;
        Field = new char[Height, Width];
        resize();
    }
	private void resize()
	{
        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                Field[i, j] = GetElement(i, j);
            }
        }
    }
	public char GetElement(int x, int y)
	{
		if (x == 0 && y == 0)
		{
			return CharacterUtilities.TopLeft;
		}
		if (x == 0 && y == Width - 1)
		{
			return CharacterUtilities.TopRig;
		}
		if (x == Height - 1 && y == 0)
		{
			return CharacterUtilities.BotLeft;
		}
		if (x == Height - 1 && y == Width - 1)
		{
			return CharacterUtilities.BotRig;
		}
		if (x == 0 || x == Height - 1)
		{
			return CharacterUtilities.Horiz;
		}
		if (y == 0 || y == Width - 1)
		{
			return CharacterUtilities.Verti;
		}
		return CharacterUtilities.Empty;
	}
	public char Get(int x, int y)
	{
		return Field[x, y];
	}
}