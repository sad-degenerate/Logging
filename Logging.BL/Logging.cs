using System;
using System.IO;
using System.Threading;

namespace Logging.BL
{
    public class Logging
    {
        public string FilePath { get; }
        public int Interval { get; }
        public string DestFolder { get; }

        public Logging(string path, string destFolder, int interval)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path), "Путь к файлу для логирования не может быть пустым.");
            if (interval <= 0)
                throw new ArgumentException("Интервал между логированием файла не может быть меньше либо равен нулю.", nameof(interval));
            if (!File.Exists(path))
                throw new FileNotFoundException("Не найден файл по указанному пути.", nameof(path));
            if (string.IsNullOrWhiteSpace(destFolder))
                throw new ArgumentNullException(nameof(destFolder), "Путь для создания логов не может быть пустым.");
            if (!Directory.Exists(destFolder))
                throw new ArgumentException("Не найдена директория по указанному пути.", nameof(destFolder));

            FilePath = path;
            Interval = interval;
            DestFolder = destFolder;
        }

        public void StartLogging()
        {
            while(true)
            {
                try
                {
                    var dateTime = DateTime.Now;
                    var dateString = $"{dateTime.Day}-{dateTime.Month}-{dateTime.Year}_" +
                                    $"{dateTime.Hour}-{dateTime.Minute}-{dateTime.Second}";

                    File.Copy(FilePath, $@"{DestFolder}\{dateString}_{Path.GetFileName(FilePath)}");
                    Thread.Sleep(Interval * 1000);
                }
                catch(Exception) 
                {
                    // TODO: Добавить вывод ошибки (например в случае удаления файла во время работы программы).
                    break;
                }
            }
        }
    }
}