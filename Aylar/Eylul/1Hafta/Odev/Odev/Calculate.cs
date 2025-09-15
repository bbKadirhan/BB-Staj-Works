public static class Calculate
{
    public static void plus()
    {
        while (true)
        {
            string? input;
            double n1; double n2;
            Console.WriteLine();
            Console.WriteLine("Brinici numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n1)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n1 = Convert.ToDouble(input);
            Console.WriteLine();
            Console.WriteLine("ikinci numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n2)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n2 = Convert.ToDouble(input);
            double sonuc = n1 + n2;
            Console.WriteLine();
            Console.WriteLine($"{n1} + {n2} sayının toplamı = {sonuc}");
            Console.WriteLine();
            break;
        }
    }
    public static void minus()
    {
        while (true)
        {
            string? input;
            double n1; double n2;
            Console.WriteLine();
            Console.WriteLine("Brinici numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n1)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n1 = Convert.ToDouble(input);
            Console.WriteLine();
            Console.WriteLine("ikinci numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n2)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n2 = Convert.ToDouble(input);
            double sonuc = n1 - n2;
            Console.WriteLine();
            Console.WriteLine($"{n1} - {n2} sayının çıkartımı = {sonuc}");
            Console.WriteLine();
            break;
        }
    }
    public static void multiply()
    {
        while (true)
        {
            string? input;
            double n1; double n2;
            Console.WriteLine();
            Console.WriteLine("Brinici numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n1)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n1 = Convert.ToDouble(input);
            Console.WriteLine();
            Console.WriteLine("ikinci numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n2)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n2 = Convert.ToDouble(input);
            double sonuc = n1 * n2;
            Console.WriteLine();
            Console.WriteLine($"{n1} * {n2} sayının çarpımı = {sonuc}");
            Console.WriteLine();
            break;
        }
    }
    public static void divide()
    {
        while (true)
        {
            string? input;
            double n1; double n2;
            Console.WriteLine();
            Console.WriteLine("Brinici numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n1)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
             n1 = Convert.ToDouble(input);
            Console.WriteLine();
            Console.WriteLine("ikinci numarayı giriniz");
            input = Console.ReadLine();
            if (!double.TryParse(input, out n2)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Bir numara girdiğinizden emin olun"); Console.ResetColor(); continue; }
            n2 = Convert.ToDouble(input);
            double sonuc = n1 / n2;
            Console.WriteLine();
            Console.WriteLine($"{n1} / {n2} sayının bölümü = {sonuc}");
            Console.WriteLine();
            break;
        }
    }
}