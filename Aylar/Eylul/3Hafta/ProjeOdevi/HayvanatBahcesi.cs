namespace HayvanatBahcesi
{
    public abstract class Hayvan
    {
        public string Ad = "";
        public string Tur = "";
        public int Yas = 0;

        public abstract void SesCikar();
        public virtual void BilgiGoster(Hayvan hayvan)
        {
            Console.WriteLine($"{hayvan.GetType().Name}, Hayvanın adı: {Ad}, Türü: {Tur}, Yaşı: {Yas}");
            Console.WriteLine();
        }
    }

    class Kopek : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine($"Kopek: {Ad}, {Tur}: Hav Hav");
        }
    }
    class Kedi : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine($"Kedi: {Ad}, {Tur}: Miyav");
        }
    }
    class Kus : Hayvan
    {
        public override void SesCikar()
        {
            Console.WriteLine($"Kuş: {Ad}, {Tur}: Cik Cik");
        }
    }

    static class Yonetim
    {
        static List<Hayvan> Hayvanlar = new List<Hayvan>();

        public static void HayvanEkle(Hayvan h) {
            Hayvanlar.Add(h);
        }
        public static void HayvanlariListele()
        {
            Console.Clear();
            foreach (Hayvan hayvan in Hayvanlar)
            {
                hayvan.BilgiGoster(hayvan);
                Console.WriteLine();
            }
        }

        public static void SesleriCal()
        {
            Console.Clear();
            foreach (Hayvan hayvan in Hayvanlar)
            {
                hayvan.SesCikar();
                Console.WriteLine();
            }
        }
    }
    
}
