public static class soru7
{
    public static void BubbleSort(string[] parts)
    {
        int n = parts.Length;
        int[] numbers = parts.Select(int.Parse).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    Console.WriteLine("Yer değişimi: " + numbers[j] + " <-> " + numbers[j + 1]);
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                    Console.WriteLine("Geçici Durum: " + string.Join(", ", numbers));
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Sıralanmış Sayılar: " + string.Join(", ", numbers));
    }
}