public class Ogrenci
{
    public string ad = "";
    public string soyad = "";

    public int NotOrtalama = 0;

    public void BilgiYazdir()
    {
        if (NotOrtalama < 0 || NotOrtalama > 100)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{ad} {soyad} kişinin not ortalaması {NotOrtalama} olamaz.");
            Console.ResetColor();
        }
        Console.WriteLine($"{ad} {soyad} öğrencisi - not ortalaması: {NotOrtalama}");
    }
}