using System.ComponentModel;

internal class Peddle
{
    private int _x, _y, leng = 4;
    private readonly Board _board;
    private readonly GamePlayer _player;
    private readonly string str;
    private Direction dir = Direction.Stop;
    private bool stopFlg = false;
    public ConsoleKey Up, Down;
    private Ball _ball;

    public Peddle(Board board, GamePlayer number)
    {
        _board = board;
        _player = number;
        if (_player == GamePlayer.First)
        {
            _x = _board.StartX + _board.HalfH - leng / 2;
            _y = _board.StartY + 1;
            Up = ConsoleKey.W;
            Down = ConsoleKey.S;
        }
        else
        {
            _x = _board.StartX + _board.HalfH - leng / 2;
            _y = _board.StartY + _board.Width - 1 - 1;
            Up = ConsoleKey.UpArrow;
            Down = ConsoleKey.DownArrow;
        }
        for (int i = 0; i < leng; ++i)
        {
            str = string.Concat(str, CharacterUtilities.Player);
        }
    }

    internal void Display()
    {
        UIUtilities.Print(_x, _y, str, Direction.Down);
    }
    internal void Remove()
    {
        UIUtilities.Erase(_x, _y, str, Direction.Down);
    }

    internal void start(Ball ball)
    {
        _ball = ball;
        Thread t = new Thread(Start);
        t.Start();
    }
    private void Start()
    {
        // StartMove();
        if (_player == GamePlayer.Auto)
        {
            dir = Direction.Up;
            do
            {
                if (MidX() > _ball.GetX())
                {
                    dir = Direction.Up;
                }
                else if (MidX() < _ball.GetX())
                {
                    dir = Direction.Down;
                }
            } while (stopFlg == false);
            return;
        }
    }
    private void StartMove()
    {
        // _ball.mpad += this.Move;
        // Thread t = new Thread(Move);
        // t.Start();
    }
    public void Move()
    {
        // do
        // {
            if (dir == Direction.Up)
            {
                if (_x == _board.StartX + 1)
                {
                    dir = Direction.Stop;
                }
                else
                {
                    Remove();
                    _x -= 1;
                    Display();
                }
            }
            else if (dir == Direction.Down)
            {
                if (_x + leng == _board.StartX + _board.Height - 1)
                {
                    dir = Direction.Stop;
                }
                else
                {
                    Remove();
                    _x += 1;
                    Display();
                }
            }
            // Thread.Sleep(180);
        // } while (stopFlg == false);
    }

    internal void stop()
    {
        stopFlg = true;
    }
    internal int StartX()
    {
        return _x;
    }
    internal int EndX()
    {
        return _x + leng - 1;
    }
    internal int MidX()
    {
        return (StartX() + EndX()) / 2;
    }

    internal void ChangeDir(Direction dire)
    {
        dir = dire;
    }
}