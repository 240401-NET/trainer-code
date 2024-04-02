namespace dndRPGdemo;

class Program
{
    static void Main(string[] args)
    {
        Character johnSmith = new("John Smith", "Fighter", 24, 15);

        Console.WriteLine(johnSmith.ToString());


    }



}
