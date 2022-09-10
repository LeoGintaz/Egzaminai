using System.Timers;

namespace Timer
{
    internal class Program

    {
        private static System.Timers.Timer aTimer;
        private static string seconds = "00";
        static void Main(string[] args)
            
        {
            Console.WriteLine("Enter Minutes :");
            var minutes = Console.ReadLine();
            string seconds = "00";
            SetTimer(minutes);

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer(string minutes)
        {
            // Create a timer with a one second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine(minutes);
        }


    }
}