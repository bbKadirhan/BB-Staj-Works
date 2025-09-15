public static class soru9
{
    public static void DengeliParantezKontrol(string input)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> parantezEslestirme = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        foreach (char ch in input)
        {
            if (parantezEslestirme.ContainsKey(ch))
            {
                stack.Push(ch);
            }
            else if (parantezEslestirme.ContainsValue(ch))
            {
                if (stack.Count == 0 || parantezEslestirme[stack.Pop()] != ch)
                {
                    Console.WriteLine();
                    Console.WriteLine("Parantezler dengeli değil.");
                    return;
                }
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Parantezler dengeli.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Parantezler dengeli değil.");
        }
    }
}