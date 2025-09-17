namespace Program
{
    class Program
    {
        public static void Main()
        {
            string? input;
            int choice;
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("1-5 arası sorular brini seçiniz");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out choice)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Hatalı giriş"); Console.ResetColor(); }
                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine();
                            Cars Toyota = new Cars();
                            Toyota.marka = "Toyota";
                            Toyota.Model = "corolla";
                            Toyota.Hizlan(4);
                            Toyota.Yavasla(7);

                            Console.WriteLine();
                            Cars Honda = new Cars();
                            Honda.marka = "Honda";
                            Honda.Model = "civic";
                            Honda.Hizlan(10);
                            Honda.Yavasla(7);

                            Console.WriteLine();
                            Cars Ford = new Cars();
                            Ford.marka = "Ford";
                            Ford.Model = "mustang";
                            Ford.Hizlan(0);
                            Ford.Yavasla(10);
                            break;
                        case 2:
                            Console.WriteLine();
                            Ogrenci Arda = new Ogrenci();
                            Arda.ad = "Arda";
                            Arda.soyad = "demir";
                            Arda.NotOrtalama = 50;
                            Arda.BilgiYazdir();

                            Console.WriteLine();
                            Ogrenci Burak = new Ogrenci();
                            Burak.ad = "Burak";
                            Burak.soyad = "tahtali";
                            Burak.NotOrtalama = 103;
                            Burak.BilgiYazdir();


                            Console.WriteLine();
                            Ogrenci Mert = new Ogrenci();
                            Mert.ad = "Mert";
                            Mert.soyad = "kara";
                            Mert.NotOrtalama = -4;
                            Mert.BilgiYazdir();
                            break;
                        case 3:
                            Console.WriteLine();
                            Domuz MyDomuz = new Domuz();
                            MyDomuz.SesCikar();

                            Console.WriteLine();
                            Civciv MyCivCiv = new Civciv();
                            MyCivCiv.SesCikar();

                            Console.WriteLine();
                            Inek MyInek = new Inek();
                            MyInek.SesCikar();
                            break;
                        case 4:
                            Console.WriteLine();
                            Personel arda = new Personel();
                            arda.ad = "Arda";
                            arda.soyad = "Demir";
                            arda.haftalikMaas = 300;
                            arda.MaasHesapla();

                            Console.WriteLine();
                            Yonetici Kadir = new Yonetici();
                            Kadir.ad = "Kadir";
                            Kadir.soyad = "Elti";
                            Kadir.haftalikMaas = 300;
                            Kadir.bonus = 200;
                            Kadir.MaasHesapla();
                            break;
                        case 5:
                            Console.WriteLine();
                            Kitap kitap1 = new Kitap();
                            kitap1.ad = "Simyacı";
                            kitap1.yazar = "Paulo Coelho";
                            kitap1.SayfaSayisi = 184;
                            kitap1.KitapBilgisi();

                            Console.WriteLine();
                            Kitap kitap2 = new Kitap();
                            kitap2.ad = "1984";
                            kitap2.yazar = "George Orwell";
                            kitap2.SayfaSayisi = 324;
                            kitap2.KitapBilgisi();

                            Console.WriteLine();
                            Kitap kitap3 = new Kitap();
                            kitap3.ad = "Suç ve Ceza";
                            kitap3.yazar = "Fyodor Dostoyevski";
                            kitap3.SayfaSayisi = 671;
                            kitap3.KitapBilgisi();
                            break;
                    }

                }
                catch (Exception)
                {
                }
            }
        }
    }
}
