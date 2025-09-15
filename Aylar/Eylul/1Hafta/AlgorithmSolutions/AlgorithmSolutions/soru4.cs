public static class soru4
{
    public static void isPalindrome(string theWord)
    {
        int left = 0;
        int right = theWord.Length - 1;
        bool isPalindrome = true;
        while (left < right)
        {
            if (theWord[left] != theWord[right])
            {
                isPalindrome = false;
                break;
            }
            left++;
            right--;
        }
        if (isPalindrome)
        {
            Console.WriteLine();
            Console.WriteLine(theWord + " bir palindromdur.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine(theWord + " bir palindrom değildir.");
        }
    }
}