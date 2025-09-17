class Kitap
{
    public string ad = "";
    public string yazar = "";
    public int SayfaSayisi = 0;

    public void KitapBilgisi()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Kitap adı: {ad}\n Yazarı: {yazar}\n SayfaSayısı: {SayfaSayisi}");
        Console.WriteLine("");
    }
}