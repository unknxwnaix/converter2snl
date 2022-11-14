using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace конвертер2snl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string path = menu1();
                ConsoleKeyInfo key = menu2(path);
                if (key.Key == ConsoleKey.Escape) { break; }
                if (key.Key == ConsoleKey.F1)
                {
                    menu3();
                }
            }
        }
        static string menu1()
        {
            // Текст первого меню и запрос пути до файла
            Console.WriteLine("Введите путь до файла (вместе с названием), который хотите открыть");
            Console.WriteLine("------------------------------------------------------------------");
            string path = Console.ReadLine();
            Console.Clear();
            return path;
        }
        static ConsoleKeyInfo menu2(string path)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                // Текст второго меню, изменение файла (в будущем, если на 5), завершение работы и начало сохранения
                Console.WriteLine("Сохранить файл в одном из трех форматов (txt, json, xml) - F1. Закрыть программу - Escape");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                if (path.Contains(".txt")) { Figure.txt_open(path); } //текст сюда
                if (path.Contains(".json")) { Figure.json_open(path); } //текст сюда
                if (path.Contains(".xml")) { Figure.xml_open(path); } //текст сюда
                key = Console.ReadKey(); // <-Info?
                if (key.Key == ConsoleKey.Escape | key.Key == ConsoleKey.F1) { break; }
                Console.Clear();
            }
            Console.Clear();
            return key;
        }
        static void menu3()
        {
            // Сохранение файла
            Console.WriteLine("Введите путь до файла (вместе с названием), куда хотите сохранить текст");
            Console.WriteLine("-----------------------------------------------------------------------");
            string path = Console.ReadLine();
            if (path.Contains(".txt")) { Figure.txt_save(path); } //текст сюда
            if (path.Contains(".json")) { Figure.json_save(path); } //текст сюда
            if (path.Contains(".xml")) { Figure.xml_save(path); } //текст сюда
            Console.Clear();
        }
    }
}