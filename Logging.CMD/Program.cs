using System;
using System.Threading;

namespace Logging.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу для производства логирования.");

            Console.Write("Введите путь к файлу, который вы собираетесь логировать: ");
            var file = Console.ReadLine();

            Console.Write("Введите папку, куда будут отправляться логи: ");
            var dir = Console.ReadLine();

            Console.Write("Введите периодичность отправки логов (в секундах): ");
            var interval = Console.ReadLine();

            Console.Clear();

            try
            {
                var log = new BL.Logging(file, dir, int.Parse(interval));

                var thread = new Thread(new ThreadStart(log.StartLogging));
                thread.Start();

                Console.WriteLine("Программа работает...");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}