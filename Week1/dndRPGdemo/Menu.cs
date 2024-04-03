/* 
Cursor parking
*******************

*******************
*/

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
        
        //One person please
        // Samat Baltin
        try{
            return Convert.ToInt32(Console.ReadLine());
        } catch(Exception e){
            Console.WriteLine(e.Message + " Entry was invalid. Please try again!");
            return -1;
        }
        
        
    }
}