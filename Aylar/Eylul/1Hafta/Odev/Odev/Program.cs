using System;

public class Program
{
    static void Main()
    {
        string invalidinput = "Geçersiz giriş lutfen doğru yazdığınızdan emin olun.";
        Console.Clear();
        while (true)
        {
            Console.WriteLine("1-5 soru cevaplarından seçiniz veya çıkmak için 'exit' yazın: ");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("clear yazarak consolu temizleyebilir siniz"); Console.ResetColor();
            string? input = Console.ReadLine();
            if (input == null) continue;
            switch (input.ToLower())
            {
                case "1":
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("1-Topla 2-Çıkar 3-Çarp 4-Böl 0-Çık");
                        input = Console.ReadLine();
                        if (input == null) continue;
                        Console.WriteLine();
                        switch (input.ToLower())
                        {
                            case "1":
                                Console.WriteLine("Toplama işlemi seçtiniz");
                                Calculate.plus();
                                break;
                            case "2":
                                Console.WriteLine("Çıkartma işlemi seçtiniz");
                                Calculate.minus();
                                break;
                            case "3":
                                Console.WriteLine("çarpma işlemi seçtiniz");
                                Calculate.multiply();
                                break;
                            case "4":
                                Console.WriteLine("Bölme işlemi seçtiniz");
                                Calculate.divide();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(invalidinput);
                                Console.ResetColor();
                                break;
                        }

                        break;
                    }
                    break;
                case "2":
                    VizeFinal.Hesapla();
                    break;
                case "3":
                    Elmas.Draw();
                    break;
                case "4":
                    NumberGame.Play();
                    break;
                case "5":
                    Dizi.Create();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "exit":
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(invalidinput);
                    Console.ResetColor();
                    Console.WriteLine();
                    continue;
            }
        }
    }
}