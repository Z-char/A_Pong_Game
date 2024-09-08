internal class MainMenu
{
	private Board _board;
	private int _x, _y, _step, _cnt = 0;
	public int Mode; // 1 represents one, 2 represents 2.
	private struct Point
	{
		public Point(int _x, int _y)
		{
			x = _x;
			y = _y;
		}
		public int x, y;
	}
	public MainMenu(Board board)
	{
		_board = board;
		_x = _board.StartX + _board.HalfH - 8;
		_y = _board.StartY + _board.HalfW;
		_step = 2;
        Start();
	}
	private void Start()
	{
		string[] str = new string[4];
		str[0] = "Pong";
		str[1] = "Single Player";
		str[2] = "Two Players";
		str[3] = "Press -UpArrow to switch up, vise versa";
		Point[] _pos = new Point[4];

		for (int i = 0; i < str.Length; ++i)
		{
			_pos[i] = Write(str[i]);
		}

		ConsoleKeyInfo key;
		int nx = _pos[1].x, ny = _pos[1].y, num = 1;
		char ch = CharacterUtilities.Cursor;
		UIUtilities.Print(nx, ny, ch);
		do
		{
			key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow)
			{
				if (num == 2)
				{
					UIUtilities.Erase(nx, ny);
					num = 1;
					nx = _pos[num].x;
					ny = _pos[num].y;
					UIUtilities.Print(nx, ny, ch);
				}
			}
			else if (key.Key == ConsoleKey.DownArrow)
			{
				if (num == 1)
				{
					UIUtilities.Erase(nx, ny);
					num = 2;
					nx = _pos[num].x;
					ny = _pos[num].y;
					UIUtilities.Print(nx, ny, ch);
				}
			}
			else if (key.Key == ConsoleKey.Enter)
			{
				Mode = num;
			}
		} while (key.Key != ConsoleKey.Enter);
		
		for (int i = 0; i < str.Length; ++i)
		{
			UIUtilities.Erase(_pos[i].x, _pos[i].y, str[i].Length + 1);
		}
	}
	private Point Write(string str)
	{
		int x = _x + _cnt * _step, y = _y - str.Length / 2;
		UIUtilities.Print(x, y, str);
		++_cnt;
		return new Point(x, y - 1);
    }
}