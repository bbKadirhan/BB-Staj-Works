using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

public static class NumberGame
{
    public static void Play()
    {
        Console.Clear();
        while (true)
        {
            string? input;
            int max;
            Random rnd = new Random();
            Console.WriteLine("Sayı bulma oyunu! Program seçtiğiniz zorluğa göre bir sayı aralığında sayı tutacak, sizde bilmeye çalışacaksınız");
            Console.WriteLine("bir zorluk seç (Kolay 1–50, Orta 1–100, Zor 1–500)");
            input = Console.ReadLine();
            if (input == null) { continue; }
            if (input.ToLower() == "kolay") { max = 50; }
            else if (input.ToLower() == "orta") { max = 100; }
            else if (input.ToLower() == "zor") { max = 500; }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçerli zorluk giriniz"); Console.ResetColor(); continue; }
            int number = rnd.Next(1, max);
            int guess;


            int denemeler = 0;
            Console.WriteLine($"Sayı tuttum! 1-{max} arası tahmin et.");
            while (true)
            {
                denemeler += 1;
                input = Console.ReadLine();
                if (input == null) { continue; }
                if (!int.TryParse(input, out guess)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("bir sayı giriniz"); Console.ResetColor(); continue; }
                guess = Convert.ToInt32(input);
                if (guess == number) { Console.WriteLine($"{guess} => Tebrikler! {denemeler} denemede bildiniz."); break; }
                else if (guess > number) { Console.WriteLine($"{guess} => yüksek"); }
                else if (guess < number) { Console.WriteLine($"{guess} => Düşük"); }
                Console.WriteLine();
            }
            break;
        }
    }
}