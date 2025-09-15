public static class soru6
{
    public static void sentinelleArama(int hedef)
    {
        List<int> sayilar = new List<int>();
        bool bulundu = false;
        for (int i = 0; i < 9; i++)
        {
            int sayi = Random.Shared.Next(1, 50);
            sayilar.Add(sayi);
        }
        for (int i = 0; i < sayilar.Count; i++)
        {
            if (sayilar[i] == hedef)
            {
                Console.WriteLine();
                Console.WriteLine(hedef + " sayısı dizide bulundu.");
                Console.WriteLine("Dizi: " + string.Join(", ", sayilar));
                Console.WriteLine();
                bulundu = true;
                break;
            }
        }
        if (!bulundu)
        {
            Console.WriteLine();
            Console.WriteLine(hedef + " sayısı dizide bulunamadı.");
            Console.WriteLine("Dizi: " + string.Join(", ", sayilar));
            Console.WriteLine();
        }
    }
}