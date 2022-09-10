namespace Tower_of_Hanoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Draw();

            Tower tower = new Tower();
            Disc disc5 = new Disc();
            Disc disc4 = new Disc();
            Disc disc3 = new Disc();
            Disc disc2 = new Disc();
            Disc disc1 = new Disc();
            disc5.size = 5;
            disc5.top = 14;
            disc4.size = 4;
            disc4.top = 13;
            disc3.size = 3;
            disc3.top = 12;
            disc2.size = 2;
            disc2.top = 11;
            disc1.size = 1;
            disc1.top = 10;

            disc5.Draw();
            disc4.Draw();
            disc3.Draw();
            disc2.Draw();
            disc1.Draw();
            Console.ReadKey();
        }
    }
}