using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        while (true)
        {

            Console.WriteLine("********** C# ile Temel Algoritma Soruları **********)");
            Console.WriteLine();
            Console.WriteLine("Görüntülemek istediğiniz Souruyu giriniz 1-10 (Çıkmak için 'Exit' yazın):");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Consolu temizlemek için ise 'Clear' yazınız.");
            Console.ResetColor();
            switch (Console.ReadLine())
            {
                case "1":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: 1’den N’e kadar doğal sayıların toplamını hesaplamak.");
                    Console.WriteLine();
                    Console.WriteLine("Formul: N = 10 + (oğrenci numranızın son rakamı)");
                    Console.WriteLine();
                    Console.WriteLine("Öğenci numaranızın son rakamını giriniz:");
                    int n = int.Parse(Console.ReadLine() ?? "0") + 10;
                    Console.WriteLine();
                    Console.WriteLine("Sonuç: " + Soru1.SumToN(n));
                    break;


                case "2":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: 8 elemanlı bir listedeki çift ve tek sayı adetini bulmak.");
                    Console.WriteLine();
                    Console.WriteLine("Istenen: Doğum gününüz GG/AA (orn: 21/02), ve numaranızın son 4 rakamı (orn: 1234)");
                    Console.WriteLine();
                    string theNumber = "";
                    while (true)
                    {
                        Console.WriteLine("Doğum gününüzu GG (orn: 21) olarak giriniz:");
                        string stringGun = Console.ReadLine() ?? "00";
                        if (stringGun.Length < 2 || int.Parse(stringGun) < 1 || int.Parse(stringGun) > 31)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen doğum gününüzü girerken 2 haneli formatta (örn: 01, 02, ..., 31) giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        theNumber += stringGun;
                        break;
                    }

                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Doğum ayınızı AA (orn: 02) olarak giriniz:");
                        string stringAy = Console.ReadLine() ?? "00";
                        if (stringAy.Length < 2 || int.Parse(stringAy) < 1 || int.Parse(stringAy) > 12)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen doğum ayınızı girerken 2 haneli formatta (örn: 01, 02, ..., 12) giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        theNumber += stringAy;
                        break;
                    }

                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Numaranızın son 4 rakamını (örn: 1234) olarak giriniz:");
                        string stringNumara = Console.ReadLine() ?? "0000";
                        if (stringNumara.Length < 4 || int.Parse(stringNumara) < 0 || int.Parse(stringNumara) > 9999)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen numaranızın son 4 rakamını girerken 4 haneli formatta (örn: 0001, 0023, ..., 9999) giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        theNumber += stringNumara;
                        break;
                    }
                    soru2.CiftTek(theNumber);

                    break;


                case "3":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: 7 elemanlı bir listede min, max ve indekslerini bulmak.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Lütfen 7 adet sayı giriniz (örn: 3 5 -5 2 8 6 4) EN AZ 1 ADET NEGATİF SAYI GİRNİZ:");
                        Console.WriteLine();
                        string? input = Console.ReadLine();
                        if (input == null) continue;

                        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 7 || parts.Length < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen tam olarak 7 adet sayı giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }

                        try
                        {
                            int[] numbers = Array.ConvertAll(parts, int.Parse);
                            int min = numbers[0], max = numbers[0];
                            int minIndex = 0, maxIndex = 0;
                            int negativesCount = 0;
                            foreach (var num in numbers)
                            {
                                if (num < 0) negativesCount++;
                            }
                            if (negativesCount < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("UYARI: Lütfen en az 1 adet negatif sayı giriniz.");
                                Console.ResetColor();
                                Console.WriteLine();
                                continue;
                            }
                            for (int i = 1; i < numbers.Length; i++)
                            {

                                if (numbers[i] < min)
                                {
                                    min = numbers[i];
                                    minIndex = i;
                                }
                                if (numbers[i] > max)
                                {
                                    max = numbers[i];
                                    maxIndex = i;
                                }
                            }

                            Console.WriteLine($"Minimum Değer: {min}, İndeks: {minIndex}");
                            Console.WriteLine($"Maksimum Değer: {max}, İndeks: {maxIndex}");
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen geçerli sayılar giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                    break;


                case "4":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: Bir kelimenin palindrom olup olmadığını iki işaretçi (left/right) ile kontrol etmek (orn: level, radar).");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Lütfen bir kelime girniz:");
                        string? word = Console.ReadLine();
                        if (string.IsNullOrEmpty(word))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen geçerli bir kelime giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        soru4.isPalindrome(word.ToLower());
                        break;
                    }
                    break;


                case "5":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: Sıcaklık Dönüşümü (°C => °F) – Dizi Üzerinde .");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("UYARI: Lütfen 5 adet santigrat cinsinden sıcaklık değeri giriniz (örn: 0 -5 20 30 40) ve aralarında boşluk bırakınız.");
                        Console.WriteLine();
                        string? tempInput = Console.ReadLine();
                        if (tempInput == null) continue;

                        string[] parts = tempInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen tam olarak 5 adet sıcaklık değeri giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }

                        try
                        {
                            int[] celsiusTemps = Array.ConvertAll(parts, int.Parse);
                            double[] fahrenheitTemps = new double[5];
                            for (int i = 0; i < celsiusTemps.Length; i++)
                            {
                                fahrenheitTemps[i] = (celsiusTemps[i] * 9.0 / 5.0) + 32.0;
                            }

                            Console.WriteLine();
                            Console.WriteLine("Girilen Santigrat Değerleri: " + string.Join(", ", celsiusTemps) + " °C");
                            Console.WriteLine("Dönüştürülen Fahrenheit Değerleri: " + string.Join(", ", fahrenheitTemps) + " °F");
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen geçerli sayılar giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                    break;

                case "6":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: Doğrusal Arama (Sentinelli)");
                    Console.WriteLine();
                    Console.WriteLine("Algoritma 9 elemanlı dizi (rastgele 1–50) içerisinde sizin berlilediğiniz hedef ile sentinelli doğrusal arama yapacak.");
                    Console.WriteLine();
                    int hedef;
                    while (true)
                    {
                        Console.WriteLine("Lütfen hedef sayıyı (1-50 arasında) giriniz:");
                        hedef = int.Parse(Console.ReadLine() ?? "00");
                        if (hedef < 1 || hedef > 50)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen hedef sayıyı 1 ile 50 arasında giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        soru6.sentinelleArama(hedef);
                        break;
                    }
                    break;
                case "7":
                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: Kabarcık Sıralama (Bubble Sort) – Küçük Bir Dizi");
                    Console.WriteLine();
                    string? inputForBubble;
                    while (true)
                    {
                        Console.WriteLine("Lütfen 7 adet sayı giriniz (örn: 3 5 -5 2 8 6 4) :");
                        inputForBubble = Console.ReadLine();
                        if (inputForBubble == null) continue;
                        string[] parts = inputForBubble.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen tam olarak 7 adet sayı giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }
                        Console.WriteLine();
                        soru7.BubbleSort(parts);
                        break;
                    }
                    break;
                case "8":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: İki sayının EBOB’unu Euclid algoritmasıyla bulmak.");
                    Console.WriteLine();

                    while (true)
                    {
                        Console.WriteLine("Lütfen iki pozitif tam sayı giriniz (örn: 48 18):");
                        string? ebobInput = Console.ReadLine();
                        if (ebobInput == null) continue;
                        string[] ebobParts = ebobInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (ebobParts.Length != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen tam olarak 2 adet pozitif tam sayı giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }
                        soru8.Ebob(ebobParts);
                        break;
                    }
                    break;


                case "9":

                    Console.WriteLine();
                    Console.WriteLine("Görevimiz: Dengeli Parantez Kontrolü (Stack Mantığı)");
                    Console.WriteLine();
                    Console.WriteLine("Algoritma, kullanıcının girdiği bir ifadedeki parantezlerin dengeli olup olmadığını kontrol edecek.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Lütfen bir ifade giriniz (örn: (a + b) * (c - d)):");
                        string? ifade = Console.ReadLine();
                        if (string.IsNullOrEmpty(ifade))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen geçerli bir ifade giriniz.");
                            Console.ResetColor();
                            continue;
                        }
                        soru9.DengeliParantezKontrol(ifade);
                        break;
                    }
                    break;
                case "10":
                    Console.WriteLine();
                    Console.WriteLine("Görevimiz:ı iki küçük listeyi tek sıralı listede birleştir.");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Lütfen ilk listeyi giriniz (örn: 1 3 5):");
                        string? firstInput = Console.ReadLine();
                        if (firstInput == null) continue;
                        string[] firstParts = firstInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (firstParts.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen en az bir sayı giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine("Lütfen ikinci listeyi giriniz (örn: 2 4 6):");
                        string? secondInput = Console.ReadLine();
                        if (secondInput == null) continue;
                        string[] secondParts = secondInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (secondParts.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen en az bir sayı giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }

                        try
                        {
                            int[] list1 = Array.ConvertAll(firstParts, int.Parse);
                            int[] list2 = Array.ConvertAll(secondParts, int.Parse);
                            soru10.MergeAndSort(list1, list2);
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("UYARI: Lütfen geçerli sayılar giriniz.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                    break;
                case "Exit":

                    Console.WriteLine("Program sonlandı.");
                    return;
                case "Clear":
                    Console.Clear();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçersiz giriş, lütfen 1-5 arasında bir sayı girin veya çıkmak için 'Exit' yazın.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
