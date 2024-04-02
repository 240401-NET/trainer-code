namespace dndRPGdemo;

class Menu 
{   
    //Print a menu, prompt the user for input
                //Menu
                    //Add a character
                    //See existing characters, and display their stats
    public static void PrintMenu()
    {
        Console.WriteLine("1. Add a character");
        Console.WriteLine("2. See existing characters and stats");
        Console.WriteLine("Enter 9 to exit");
    }

    //Takes user input and returns it to wherever this method is called
    public static int UserChoice()
    {
        return Convert.ToInt32(Console.ReadLine());
    }
}