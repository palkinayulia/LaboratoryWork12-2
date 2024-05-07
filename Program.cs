using ClassLibrary10Lab;

namespace Лабораторная_работа_12_2
{
    internal class Program
    {
        static int NumberCheck() //проверка ввода числа
        {
            bool isConvert;
            int n;
            do
            {
                Console.Write("Введите число: ");
                string input = Console.ReadLine();
                isConvert = int.TryParse(input, out n);
                if (!isConvert || n <= 0) Console.WriteLine("Неправильно введено число \nПопробуйте еще раз.");
            } while (!isConvert || n <= 0);
            return n;
        }
        static void Main(string[] args)
        {
            MyHashTable1<Watch> table = new MyHashTable1<Watch>();
            int numberMenu;
            int size = 0;
            do //меню для 2 части
            {
                Console.WriteLine("1.Создать таблицу");
                Console.WriteLine("2.Вывести таблицу");
                Console.WriteLine("3.Поиск элемента с заданным ключом");
                Console.WriteLine("4.Удалить из таблицы элемент с заданым ключом");
                Console.WriteLine("5.Добавление элемента в таблицу");
                Console.WriteLine("6.Выход");
                numberMenu = NumberCheck();
                switch (numberMenu)
                {
                    case 1: //создание таблицы
                        {
                            Console.Write("Введите количество элементов таблицы - ");
                            size = NumberCheck();
                            table = new MyHashTable1<Watch>(size); //создаем таблицу
                            for (int i = 0; i < size; i++)
                            {
                                Watch c = new Watch();
                                c.RandomInit();
                                table.AddItem(c);
                            }
                            Console.WriteLine("Таблица создана");//сообщение для пользователя
                            break;
                        };
                    case 2://печать таблицы
                        {
                            table.Print();//выводим таблицу
                            break;
                        };
                    case 3://поиск
                        {
                            Console.WriteLine("Введите элемент для поиска: ");
                            Watch clock = new Watch();
                            clock.Init();
                            if (!table.Contains(clock)) Console.WriteLine("Такого элемента нет в списке");
                            else Console.Write("Элемент найден - его номер ");
                            Console.WriteLine(table.FindItem(clock));
                            break;
                        };
                    case 4://удаление
                        {
                            Console.WriteLine("Введите элемент для удаления: ");
                            Watch clock = new Watch();
                            clock.Init();
                            if (!table.Contains(clock)) Console.WriteLine("Такого элемента нет в списке");
                            else
                            {
                                table.RemoveData(clock);
                                Console.WriteLine("Элемент удален"); //сообщение для пользователя
                            }
                            break;
                        };
                    case 5://добавление
                        {
                            Console.WriteLine("Введите элемент для добавления: ");
                            Watch clock = new Watch();
                            clock.Init();
                            table.AddData(clock);
                            Console.WriteLine("Элемент добавлен");
                            break;
                        }
                    case 6: { break; } //возвращение в главное меню
                    default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
                }
            } while (numberMenu != 6);
        }
    }
}
