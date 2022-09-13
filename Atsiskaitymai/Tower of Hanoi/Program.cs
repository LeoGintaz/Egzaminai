namespace Tower_of_Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Draw();
            //board.DrawTower();
            board.Hud();
            //-----------------//
            Tower tower1 = new Tower();
            tower1.xAxis = 7;
            Tower tower2 = new Tower();
            tower2.xAxis = 17;
            Tower tower3 = new Tower();
            tower3.xAxis = 27;
            //-----------------//
            Disk disk1 = new Disk(1);
            Disk disk2 = new Disk(2);
            Disk disk3 = new Disk(3);
            Disk disk4 = new Disk(4);
            List<string> disks = new List<string> {disk1.Generate(), disk2.Generate(), disk3.Generate(), disk4.Generate() };//Generates List of strings , by the size of each disk
            List<Tower> towers = new List<Tower> { tower1, tower2, tower3 };
            Game game = new Game();
            game.Start(towers,disks);








            Console.ReadKey();
        }
    }
}