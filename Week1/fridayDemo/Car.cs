
public class Car : IDriveable
{
    public string make {get; set;}
    public string model {get; set;}

    public void Driving()
    {
        Console.WriteLine("Driving my car!");
    }

}