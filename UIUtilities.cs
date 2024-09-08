internal class UIUtilities
{
    internal static void Erase(int x, int y)
    {
        Print(x, y, CharacterUtilities.Empty);
    }
    internal static void Erase(int x, int y, int leng)
    {
        for (int i = 0; i < leng; ++i)
        {
            Erase(x, y + i);
        }
    }

    internal static void Erase(int x, int y, string str, Direction dir)
    {
        if (dir == Direction.Down)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                Erase(x + i, y);
            }
        }
    }

    internal static void Print(Board board)
    {
        for (int i = 0; i < board.Height; ++i)
        {
            for (int j = 0; j < board.Width; ++j)
            {
                Console.SetCursorPosition(board.StartY + j, board.StartX + i);
                Console.WriteLine(board.Get(i, j));
            }
        }
    }
    internal static void Print(int x, int y, string str)
    {
        for (int i = 0; i < str.Length; ++i)
        {
            Print(x, y + i, str[i]);
        }
    }
    internal static void Print(int x, int y, char ch)
    {
        Console.SetCursorPosition(y, x);
        Console.WriteLine(ch);
    }

    internal static void Print(int x, int y, string str, Direction dir)
    {
        if (dir == Direction.Down)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                Print(x + i, y, str[i]);
            }
        }
    }
}