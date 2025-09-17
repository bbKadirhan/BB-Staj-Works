interface IHayvan
{
    void SesCikar();
}

public class Domuz : IHayvan
{
    public void SesCikar()
    {
        Console.WriteLine("Domuz: Oink oink");
    }
}

public class Civciv: IHayvan
{
    public void SesCikar()
    {
        Console.WriteLine("Civciv: çip çip");
    }
}

public class Inek: IHayvan
{
    public void SesCikar()
    {
        Console.WriteLine("Inek: Mooo Mooo");
    }
}