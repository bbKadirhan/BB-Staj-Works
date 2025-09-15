using System.Globalization;

public static class Elmas
{
    public static void Draw()
    {
        Console.Clear();
        while (true)
        {
            string? input;
            int number;
            Console.WriteLine("Kullanıcıdan tek pozitif boyut iste (örn. 7, 9, 11). Çift girerse tekrar iste.");
            Console.WriteLine();
            Console.WriteLine("Çizilecek elmas boyutunu yazınız (Tek sayı olmalı)");
            input = Console.ReadLine();
            if (input == null) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
            if (!int.TryParse(input, out number)) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
            if (number % 2 == 0) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Çift sayı geçersiz, girdiğiniz sayının tek sayı olduğundan emin olun"); Console.ResetColor(); continue; } }
            number = Convert.ToInt32(input);

            for (int i = 0; i <= number; i++)
            {
                //the line we are in i is the line row we are in
                Console.Write(new string(' ', number - i));
                Console.Write(new string('*', 2*i+1));
                Console.WriteLine();
            }
             for (int i = 1; i <= number; i++)
            {
                //the line we are in i is the line row we are in
                Console.Write(new string(' ', number - (number-i)));
                Console.Write(new string('*', (number*2)-(i*2)+1));
                Console.WriteLine();
            }
            Console.WriteLine();
            break;
        }
    }
}