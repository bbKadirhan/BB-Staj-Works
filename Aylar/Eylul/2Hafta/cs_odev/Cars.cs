public class Cars
{
    public string marka = "";
    public string Model = "";
    public int speed = 0;

    public void Hizlan(int Value)
    {
        if (0 <= speed && speed <= 100)
        {
            for (int i = 0; i < Value; i++)
            {
                speed += 1;
                Console.WriteLine($"{Model} {marka} aracın hızı: {speed}");
            }
        }
    }

    public void Yavasla(int Value)
    {
        if (-100 <= speed && speed >= 0)
        {
            for (int i = 0; i < Value; i++)
            {
                speed -= 1;
                Console.WriteLine($"{Model} {marka} aracın hızı: {speed}");
            }
        }
    }
}