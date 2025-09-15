public static class soru2{
    public static void CiftTek(string theNumber)
    {
        List<int> digits = theNumber.Select(c => int.Parse(c.ToString())).ToList();

        int tekler = 0;
        int ciftler = 0;

        for (int i = 0; i < digits.Count; i++)
        {
            if (digits[i] % 2 == 0)
            {
                ciftler++;
                Console.WriteLine(digits[i] + " - Çift bir sayıdır.");
            }
            else if (digits[i] % 2 != 0)
            {
                tekler++;
                Console.WriteLine(digits[i] + " - Tek  bir sayıdır.");
            }

        }
        Console.WriteLine();
        Console.WriteLine("Listedeki toplam çift sayı adedi: " + ciftler);
        Console.WriteLine("Listedeki toplam tek sayı adedi: " + tekler);
    }
}