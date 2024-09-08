public delegate void TouchPad();

internal class Ball
{
	public event TouchPad tpad, mpad;
	private Board board;
	private int _Sx, _Sy, _nx, _ny;
	private Direction _dir = Direction.Up | Direction.Right;
	private char ball;
	private bool stopFlg = false;

	public Ball(Board board)
	{
		this.board = board;
		_Sx = board.StartX + board.HalfH;
		_Sy = board.StartY + board.HalfW;
		_nx = _Sx;
		_ny = _Sy;
		ball = CharacterUtilities.Ball;
	}

	internal void display()
	{
		UIUtilities.Print(_nx, _ny, ball);
	}

    internal void start(Peddle ped1, Peddle ped2)
    {
		do
		{
			if (_nx == board.StartX + 1)
			{
				_dir = (Direction)(int)_dir - (int)Direction.Up;
				_dir = (Direction)(int)_dir + (int)Direction.Down;
			}
			else if (_nx == board.StartX + board.Height - 1 - 1)
			{
                _dir = (Direction)(int)_dir + (int)Direction.Up;
                _dir = (Direction)(int)_dir - (int)Direction.Down;
            }
			if (_ny == board.StartY)
			{
				stopFlg = true;
			}
			else if (_ny == board.StartY + board.Width - 1)
			{
				stopFlg = true;
			}
			if (_ny == board.StartY + 1)
			{
				if (Collision(ped1))
				{
					_dir = (Direction)(int)_dir - (int)Direction.Left;
                    _dir = (Direction)(int)_dir + (int)Direction.Right;
                }
			}
			else if (_ny == board.StartY + board.Width - 1 - 1)
			{
				if (Collision(ped2))
				{
                    _dir = (Direction)(int)_dir + (int)Direction.Left;
                    _dir = (Direction)(int)_dir - (int)Direction.Right;
                }
			}
			// could be packaged into a function
			UIUtilities.Erase(_nx, _ny);
			if (((int)_dir & (int)Direction.Right) != 0)
			{
				_ny += 1;
			}
			else
			{
				_ny -= 1;
			}
			if (((int)_dir & (int)Direction.Up) != 0)
			{
				_nx -= 1;
			}
			else
			{
				_nx += 1;
			}
			display();
			if (mpad != null)
			{
				mpad();
			}
			Thread.Sleep(180);
		} while (stopFlg == false);
		if (tpad != null)
		{
			tpad();
		}
    }

    private bool Collision(Peddle ped)
    {
		int _x1 = ped.StartX(), _x2 = ped.EndX();
		if (_x1 <= _nx && _nx <= _x2)
		{
			return true;
		}
		return false;
    }
	public int GetX()
	{
		return _nx;
	}
}