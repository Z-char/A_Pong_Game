internal class InputScanner
{
    private Peddle[] ped;
    private bool stopFlg = false;

    public InputScanner(Peddle ped1, Peddle ped2)
    {
        ped = new Peddle[2];
        ped[0] = ped1;
        ped[1] = ped2;
        Thread t = new Thread(StartScan);
        t.Start();
    }
    private void StartScan()
    {
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);

            for (int i = 0; i < 2; ++i)
            {
                var pp = ped[i];
                if (key.Key == pp.Up)
                {
                    pp.ChangeDir(Direction.Up);
                }
                else if (key.Key == pp.Down)
                {
                    pp.ChangeDir(Direction.Down);
                }
            }
        } while (stopFlg == false);
    }
    internal void stop()
    {
        stopFlg = true;
    }
}