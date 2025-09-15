public class VizeFinal
{
    public static void Hesapla()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("N öğrencinin Vize ve Final notunu al (0–100)");
            string? input;
            int students;
            double Vize; double Final; double sonuc;
            string not;
            List<string> notlar = new List<string>();
            List<string> passed = new List<string>();
            List<string> failed = new List<string>();
            List<double> sonuclar = new List<double>();

            //variables

            Console.WriteLine();
            Console.WriteLine("Not girilecek öğrenci sayısı giriniz");
            input = Console.ReadLine();
            if (!int.TryParse(input, out students)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz oğrenci sayısı girdiniz"); Console.ResetColor(); continue; }
            students = Convert.ToInt32(input);
            //getting input

            for (int i = 1; i <= students; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i}: oğrencisi için Vize notunu giriniz");
                input = Console.ReadLine();
                if (!double.TryParse(input, out Vize)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz oğrenci sayısı girdiniz"); Console.ResetColor(); continue; }
                Vize = Convert.ToDouble(input);
                if (Vize < 0 || Vize > 100) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz sayı girdiniz"); Console.ResetColor(); continue; }
                Console.WriteLine();

                Console.WriteLine($"{i}: oğrencisi için Final notunu giriniz");
                input = Console.ReadLine();
                if (!double.TryParse(input, out Final)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz oğrenci sayısı girdiniz"); Console.ResetColor(); continue; }
                Final = Convert.ToDouble(input);
                if (Final < 0 || Final > 100) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz sayı girdiniz"); Console.ResetColor(); continue; }
                Console.WriteLine();

                sonuc = ((Vize * 0.4) + (Final * 0.6));
                if (sonuc > 90 && sonuc <= 100) { not = "A"; passed.Add($"{i}: Öğrencisi {sonuc} {not}");}
                else if (sonuc >= 80 && sonuc <= 89) { not = "B"; passed.Add($"{i}: Öğrencisi {sonuc} {not}");}
                else if (sonuc >= 70 && sonuc <= 79) { not = "C"; passed.Add($"{i}: Öğrencisi {sonuc} {not}");}
                else if (sonuc >= 60 && sonuc <= 69) { not = "D"; passed.Add($"{i}: Öğrencisi {sonuc} {not}");}
                else if (sonuc < 60) { not = "F"; failed.Add($"{i}: Öğrencisi {sonuc} {not}");}
                else { not = "Hata"; }
                sonuclar.Add(sonuc);
                notlar.Add($"{i}: Öğrencisi {sonuc} {not}");
            }
            //printing he result

            double avarage = sonuclar.Average();
            double highest = sonuclar.Max();
            double lowest = sonuclar.Min();

            Console.Clear();
            Console.WriteLine("--Öğrenci notları--");
            foreach (string student in notlar)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine($"Sınıf en yüksek notu: {highest}");
            Console.WriteLine($"Sınıf ortalaması: {avarage}");
            Console.WriteLine($"Sınıf en düşük notu: {lowest}");
            
            Console.WriteLine();
            Console.WriteLine("--Sınıfı Geçenler");
            foreach (string student in passed) {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("--Sınıfı Geçemeyenler");
            foreach (string student in failed) {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            break;
        }
    }
}