public static class soru8
{
    public static void Ebob(string[] parts)
    {
        int a = int.Parse(parts[0]);
        int b = int.Parse(parts[1]);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        Console.WriteLine();
        Console.WriteLine("EBOB: " + a);
        Console.WriteLine();
    }
}