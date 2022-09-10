namespace Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Map map = new Map();
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

            game.Draw(disk4.Object(), map.tower[0], map.line[0]);

            
            game.Draw(disk3.Object(), map.tower[0], map.line[1]);





            Console.ReadKey();
        }

    }
}