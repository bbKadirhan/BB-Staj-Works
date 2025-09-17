public class Personel
{
    public string ad = "";
    public string soyad = "";
    public int haftalikMaas = 0;
    public int maas = 0;

    public void MaasHesapla()
    {
        maas = haftalikMaas * 3;
        Console.WriteLine($"{ad} {soyad} Kişinin maasşı: {maas}");
    }
}

public class Yonetici : Personel
{
    public int bonus = 0;
    public new void MaasHesapla()
    {
        maas = (haftalikMaas * 3) + bonus;
        Console.WriteLine($"{ad} {soyad} Kişinin maasşı: {maas}");
    }
}