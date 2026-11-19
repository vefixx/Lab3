namespace Part2;

class Program
{
    private static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Money");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": Task1(); break;
                case "0": exit = true; break;
                default: Console.WriteLine("Неверный ввод."); break;
            }
        }
    }

    private static void Task1()
    {
        Money m1 = new Money(500, 75);
        Console.WriteLine($"1. new Money(500, 75) => {m1}");

        Console.Write("2. new Money(0, 150) => ");
        try
        {
            Money bad = new Money(0, 150);
            Console.WriteLine(bad);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Исключение");
        }

        Money m2 = m1.AddKopeks(50);
        Console.WriteLine($"3. AddKopeks(50) => {m2}");

        Money m3 = m1 + 125;
        Console.WriteLine($"4. m + 125 => {m3}");

        Money m4 = 125 + m1;
        Console.WriteLine($"5. 125 + m => {m4}");

        Money m5 = m1 - 50;
        Console.WriteLine($"6. m - 50 => {m5}");

        Console.Write("7. m - 100000 => ");
        try
        {
            Money bad = m1 - 100000;
            Console.WriteLine(bad);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Исключение");
        }

        Money m6 = 60000 - m1;
        Console.WriteLine($"8. 60000 - m => {m6}");

        Console.Write("9. 100 - m => ");
        try
        {
            Money bad = 100 - m1;
            Console.WriteLine(bad);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Исключение: {e.GetType()}");
        }

        Money m7 = new Money(10, 5);
        Console.WriteLine($"10. До --: {m7}");
        m7--;
        Console.WriteLine($"После --: {m7}");

        Console.Write("11. -- от 0 руб 0 коп => ");
        try
        {
            Money zero = new Money(0, 0);
            zero--;
            Console.WriteLine(zero);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Исключение");
        }

        uint u = (uint)m1;
        Console.WriteLine($"12. (uint)m => {u}");

        double dbl = m1;
        Console.WriteLine($"13. double d = m => {dbl}");

        Console.WriteLine();
    }
}