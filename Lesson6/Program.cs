using System;
using System.IO;
using System.Text;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "directory.txt"; //Путь к файлу
            

            while (true)
            {
                Console.WriteLine("\nВыбирите действие:1-вывести данные, 2 - Записать данные");
                string act = Console.ReadLine();
                switch (act)
                {
                    /*При вводе пользователем цифры 1 проверяем есть ли файл. 
                     * Если есть, то выводим данные в консоль, иначе уведомляем об этом пользователя. 
                     * При вводе цифры 1 Записываем данные в файл.
                     */
                    case "1":
                        if (File.Exists(file))
                        {
                            ReadFile(file);
                        }
                        else 
                        {
                            Console.WriteLine("Невозможно прочитать файл. Файл не существует.");
                        }
                        break;
                    case "2":
                        WriteFile(file);
                        break;
                    default:
                        Console.WriteLine("Нет такого действия");
                        break;
                }
                                  
            }

        }

        /// <summary>
        /// Метод записывает данные в файл
        /// </summary>
        /// <param name="file">Путь к файлу</param>
        static void WriteFile(string file)
        {
           
            using (StreamWriter sw = new StreamWriter(file, true, Encoding.Unicode))
            {
                string note = String.Empty;
                Console.Write("Введите ID:");
                note += $"{Console.ReadLine()}#";

                string nowDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                Console.WriteLine($"Дата создания записи {nowDate}");
                note += $"{nowDate}#";

                Console.Write("Введите ФИО:");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите возраст:");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите Рост:");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите Дату рождения:");
                note += $"{Console.ReadLine()}#";

                Console.Write("Введите место рождения:");
                note += $"город {Console.ReadLine()}#";
                sw.WriteLine(note);
            }
        }

        /// <summary>
        /// Метод считывает данные из файла и выводит в консоль
        /// </summary>
        /// <param name="file">Путь к файлу</param>
        static void ReadFile(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"\n{"ID",2}|{"Дата создания",17} |{"ФИО",30}|{"Возраст",8}|{"Рост",5}|{"Дата рождения",15}|{"Место рождения"}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split("#");
                    Console.WriteLine($"{data[0],2}|{data[1],17} |{data[2],30}|{data[3],8}|{data[4],5}|{data[5],15}|{data[6]}");
                }
            }
        }
    }    
}
