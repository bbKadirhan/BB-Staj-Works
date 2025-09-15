public static class soru10
{
    public static void MergeAndSort(int[] list1, int[] list2)
    {
        List<int> mergedList = new List<int>(list1);
        mergedList.AddRange(list2);
        mergedList.Sort();
        Console.WriteLine();
        Console.WriteLine("Birleştirilmiş ve Sıralanmış Liste: " + string.Join(", ", mergedList));
    }
}