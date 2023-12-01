using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Convertor_0_0
{
    internal class Reading
    {
        public Reading()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием) или нажмите Escape для выхода:");
            Console.WriteLine("-----------------------------------------------------------------");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nВыход из программы!");
                    break; // Выход из цикла и программы
                }

                try
                {
                    string way_1 = Console.ReadLine();

                    

                    string myText = File.ReadAllText(way_1);
                    Console.Clear();

                    Console.WriteLine("Для того чтобы сохранить файл в одном из трёх форматов (txt, json, xml) - F1. Закрыть программу - Escape");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(myText);

                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.F1)
                    {
                        Console.Clear();

                        Console.WriteLine("Введите путь до файла (вместе с названием), куда вы хотите сохранить текст");
                        Console.WriteLine("--------------------------------------------------------------------------");

                        string way_2 = Convert.ToString(Console.ReadLine());

                        if (way_2.EndsWith(".json"))
                        {
                            File.WriteAllText(way_2, JsonConvert.SerializeObject(myText));
                        }
                        else if (way_2.EndsWith(".xml"))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(string));
                            using (TextWriter writer = new StreamWriter(way_2))
                            {
                                xmlSerializer.Serialize(writer, myText);
                            }
                        }
                        else
                        {
                            File.WriteAllText(way_2, myText);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка, попробуйте снова: ");
                }
                break;
           
            }
        }
    }
}
