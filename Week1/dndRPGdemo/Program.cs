namespace dndRPGdemo;

class Program
{
    static void Main(string[] args)
    {
        //TODO: Create list to store characters

        //TODO: Add more hardcoded characters, append them to list
        Character johnSmith = new("John Smith", "Fighter", 24, 15);

        //We user Console.Writeline to write output to the console
        Console.WriteLine(johnSmith.ToString());

        //TODO: Create Switch Menu inside while loop w/user input

        //TODO: Validate User Input with try-catch


    }



}
