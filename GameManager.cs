internal class GameManager
{
    private Board _board;
    private Ball _ball;
    private MainMenu _mainMenu;
    private Peddle _ped1, _ped2;
    private InputScanner _inputScanner;

	internal bool RestartCheck()
	{
        // throw new NotImplementedException();
        return true;
	}

	internal void Start()
	{
		Console.CursorVisible = false;
		Console.ForegroundColor = ConsoleColor.White;

		InitializeInstances();
        SetPlayer();
        SetInputScanner();

        _ball.display();
        _ped1.Display();
        _ped2.Display();
        // WaitForStart();
        GameStart();
	}

    private void GameStart()
    {
        _ball.tpad += _ped1.stop;
        _ball.tpad += _ped2.stop;
        _ball.tpad += _inputScanner.stop;

        _ball.mpad += _ped1.Move;
        _ball.mpad += _ped2.Move;

        _ped1.start(_ball);
        _ped2.start(_ball);
        _ball.start(_ped1, _ped2);
    }

    private void WaitForStart()
    {
        // output a line above the ball: Press anykey to start.
        throw new NotImplementedException();
    }

    private void SetPlayer()
    {
        _ped1 = new Peddle(_board, GamePlayer.First);
        if (_mainMenu.Mode == 1)
        {
            _ped2 = new Peddle(_board, GamePlayer.Auto);
        }
        else
        {
            _ped2 = new Peddle(_board, GamePlayer.Second);
        }
    }

    private void InitializeInstances()
    {
        SetBoard();
        SetMenu();
        SetBall();
        UIUtilities.Print(_board);
    }

    private void SetInputScanner()
    {
        _inputScanner = new InputScanner(_ped1, _ped2);
    }

    private void SetBoard()
    {
        _board = new Board(24, 90, 5, 5); // new a board.
        UIUtilities.Print(_board); // print the board.
    }
    private void SetBall()
    {
        _ball = new Ball(_board);
    }
    private void SetMenu()
    {
        _mainMenu = new MainMenu(_board); // new a menu related to the board.
    }
}