namespace Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Draw();// nupiesia sona ir apacia
            board.DrawTower(); // nupiesia stulpu centrus
            //---------------------
            //Disks
            Disk disk4 = new Disk();
            disk4.size = 4;
            //------------------------
            Disk disk3 = new Disk();
            disk3.size = 3;
            //------------------------
            
            //-----------------------
            Game game = new Game();
            game.line = 4;
            game.Draw(disk4.Object());
            game.line = 3;
            game.Draw(disk3.Object());





            Console.ReadKey();
        }

    }
}