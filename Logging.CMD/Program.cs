using System.Threading;

namespace Logging.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"D:\Logging test\log.txt";
            var dest = @"D:\Logging test\logs";
            var interval = 10;

            var log = new BL.Logging(file, dest, interval);

            var thread = new Thread(new ThreadStart(log.StartLogging));
            thread.Start();
        }
    }
}