public static class Dizi
{
    public static void Create()
    {
        Console.Clear();
        while (true)
        {
            string? input; string? tempinput;
            int number; double temp;
            Console.WriteLine("Sizden dizi boyutu isteyeceğiz, o dizide tam sayıdan oluşan bir dizi oluştüracaksınız");
            Console.WriteLine();
            Console.WriteLine("Dizi boyutu giriniz (orn: 0,1,5,10...)");
            input = Console.ReadLine();
            if (input == null) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
            if (!int.TryParse(input, out number)) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
            number = Convert.ToInt32(input);
            List<double> dizi = new List<double>();
            while (true)
            {
                dizi.Clear();
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Dizinin {i}, sayısını giriniz ");
                    tempinput = Console.ReadLine();
                    if (tempinput == null) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); break; } }
                    if (!double.TryParse(tempinput, out temp)) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); break; } }
                    temp = Convert.ToDouble(tempinput);
                    dizi.Add(temp);
                }
                if (dizi.Count != number) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("yeterli sayı girilmedi"); Console.ResetColor(); continue; } }
                break;
            }
            
           
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"N: {number} => [{string.Join(", ", dizi)}]");
            Console.WriteLine();
            Console.WriteLine($"Min: {dizi.Min()} Max: {dizi.Max()} Toplam: {dizi.Sum()} Ort: {dizi.Average()}");


            double aranacak;
            List<double> bulunanlar = new List<double>();
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Aramak istediğiniz sayıyı giriniz");
                input = Console.ReadLine();
                if (input == null) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
                if (!double.TryParse(input, out aranacak)) { { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz giriş"); Console.ResetColor(); continue; } }
                aranacak = Convert.ToDouble(input);
                for (int i = 0; i < dizi.Count; i++)
                {
                    if (dizi[i] == aranacak) { bulunanlar.Add(i); }
                }
                break;

            }
            Console.WriteLine();
            Console.WriteLine($"Ara: {aranacak} indexler: {string.Join(", ", bulunanlar)}");


            for (int i = 0; i < dizi.Count - 1; i++)
            {
                for (int j = 0; j < dizi.Count - i - 1; j++)
                {
                    if (dizi[j] > dizi[j + 1])
                    {
                        temp = dizi[j];
                        dizi[j] = dizi[j + 1];
                        dizi[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Sırala => [{string.Join(", ", dizi)}]");

            double median;

            int count = dizi.Count;
            if (count % 2 == 1)
            {
                median = dizi[count / 2];

                Console.WriteLine();
                Console.WriteLine($"Medyan: {dizi[count / 2]} = {median}");

            }
            else
            {
                median = (dizi[(count / 2) - 1] + dizi[count / 2]) / 2;

                Console.WriteLine();
                Console.WriteLine($"Medyan: {dizi[(count / 2) - 1]} + {dizi[count / 2]} / 2 = {median}");
            }

            Console.WriteLine();
            

            break;
        }
    }
}