namespace Part1;

class Program
{
    static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Заменить первое вхождение подсписка");
                Console.WriteLine("2. Отсортировать LinkedList");
                Console.WriteLine("3. Анализ множеств игр");
                Console.WriteLine("4. Найти отсутствующие глухие буквы");
                Console.WriteLine("5. Вывести победителей");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите задание: ");
                
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    case "5": Task5(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        }

        static void Task1()
        {
            List<int> l1 = ReadIntList("l1");
            List<int> l2 = ReadIntList("l2");
            List<int> l3 = ReadIntList("l3");
            
            bool res = Solutions.TryReplaceFirstEntry(l1, l2, l3);
            Console.WriteLine("Результат: " + res);
            if (res) Console.WriteLine("l1: " + string.Join(", ", l1));
            Console.WriteLine();
        }

        static void Task2()
        {
            LinkedList<int> list = new LinkedList<int>(ReadIntList("LinkedList"));
            Solutions.SortAsc(list);
            Console.WriteLine("Результат: " + string.Join(", ", list));
            Console.WriteLine();
        }

        static void Task3()
        {
            HashSet<string> allGames = ReadStringSet("все игры");
            
            int n = ReadInt("Количество студентов: ");
            
            List<HashSet<string>> studentGames = new List<HashSet<string>>();
            for (int i = 0; i < n; i++)
            {
                studentGames.Add(ReadStringSet($"студент {i + 1}"));
            }
            
            Solutions.AnalyzeGameSets(allGames, studentGames, out HashSet<string> allPlay, out HashSet<string> somePlay, out HashSet<string> nonePlay);
            
            Console.WriteLine("Все играют: " + string.Join(", ", allPlay));
            Console.WriteLine("Некоторые играют: " + string.Join(", ", somePlay));
            Console.WriteLine("Никто не играет: " + string.Join(", ", nonePlay));
        }

        static void Task4()
        {
            string path = ReadString("Путь к файлу: ");
            char[] res = Solutions.FindMissingDeafChars(path);
            Console.WriteLine("Отсутствующие буквы: " + new string(res));
            Console.WriteLine();
        }

        static void Task5()
        {
            string path = ReadString("Путь к файлу: ");
            Console.WriteLine("Победители:");
            Solutions.PrintWinners(path);
            Console.WriteLine();
        }

        static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static List<int> ReadIntList(string name)
        {
            Console.Write($"Введите элементы {name} через пробел: ");
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<int> list = new List<int>();
            foreach (string p in parts) list.Add(int.Parse(p));
            return list;
        }

        static HashSet<string> ReadStringSet(string prompt)
        {
            Console.Write($"Введите элементы {prompt} через пробел: ");
            string[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new HashSet<string>(parts);
        }
}