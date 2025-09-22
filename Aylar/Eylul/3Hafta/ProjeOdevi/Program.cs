using HayvanatBahcesi;

namespace Program
{
    class Program{
        public static void Main()
        {
            string? input;
            int choose;
            bool Close = false;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1. Yeni hayvan ekle");
                Console.WriteLine("2. hayvanları listele");
                Console.WriteLine("3. tum hayvanlara ses çıkart");
                Console.WriteLine("4. çıkış");
                input = Console.ReadLine();
                if (!int.TryParse(input, out choose)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                if (choose < 0 || 4 < choose) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Eklemek istediğiniz hayvanın numarasını giriniz");
                            Console.WriteLine("1. Kopek");
                            Console.WriteLine("2. kedi");
                            Console.WriteLine("3. kus");
                            input = Console.ReadLine();
                            if (!int.TryParse(input, out choose)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                            switch (choose)
                            {
                                case 1:
                                    HayvanatBahcesi.Kopek YeniKopek = new HayvanatBahcesi.Kopek();
                                    Console.WriteLine();
                                    Console.WriteLine("kopeğin ismini giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKopek.Ad = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kopeğin türünü giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKopek.Tur = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kopeğin Yaşini giriniz");
                                    input = Console.ReadLine();
                                    if (!int.TryParse(input, out choose)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    if (choose < 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz yaş"); Console.ResetColor(); continue; }
                                    YeniKopek.Yas = choose;

                                    HayvanatBahcesi.Yonetim.HayvanEkle(YeniKopek);
                                    break;
                                case 2:
                                    HayvanatBahcesi.Kedi YeniKedi = new HayvanatBahcesi.Kedi();
                                    Console.WriteLine();
                                    Console.WriteLine("kedinin ismini giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKedi.Ad = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kedinin türünü giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKedi.Tur = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kedinin Yaşini giriniz");
                                    input = Console.ReadLine();
                                    if (!int.TryParse(input, out choose)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    if (choose < 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz yaş"); Console.ResetColor(); continue; }
                                    YeniKedi.Yas = choose;

                                    HayvanatBahcesi.Yonetim.HayvanEkle(YeniKedi);
                                    break;
                                case 3:
                                    HayvanatBahcesi.Kus YeniKus = new HayvanatBahcesi.Kus();
                                    Console.WriteLine();
                                    Console.WriteLine("kuşun ismini giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKus.Ad = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kuşun türünü giriniz");
                                    input = Console.ReadLine();
                                    if (input == string.Empty) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    YeniKus.Tur = input;
                                    Console.WriteLine();
                                    Console.WriteLine("kuşun Yaşini giriniz");
                                    input = Console.ReadLine();
                                    if (!int.TryParse(input, out choose)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Geçersiz Giriş!"); Console.ResetColor(); continue; }
                                    if (choose < 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("geçersiz yaş"); Console.ResetColor(); continue; }
                                    YeniKus.Yas = choose;

                                    HayvanatBahcesi.Yonetim.HayvanEkle(YeniKus);
                                    break;
                            }
                            break;
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        HayvanatBahcesi.Yonetim.HayvanlariListele();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        HayvanatBahcesi.Yonetim.SesleriCal();
                        Console.WriteLine();
                        break;
                    case 4:
                        Close = true;
                        break;
                }
                if (Close == false) { continue; }
                break;
            }
        }
    }
}