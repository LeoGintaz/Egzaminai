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
            tower1.Draw();
            tower2.Draw();
            tower3.Draw();







            Console.ReadKey();
        }
    }
}