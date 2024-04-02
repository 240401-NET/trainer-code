namespace dndRPGdemo;

class Program
{
    static void Main(string[] args)
    {
        /* I can make a block comment like this.
        Everything between the two slash+asterisks will be a comment
        This way I can easily do multi-line comments */

        //Create list to store characters
        List<Character> characterList = new();

        //Add more hardcoded characters, append them to list
        Character johnSmith = new("John Smith", "Fighter", 24, 15);
        Character django = new("Django", "Rogue", 27, 12);
        Character shrek = new("Shrek", "Ogre", 32, 44);

        //Appending characters to the list 
        characterList.Add(shrek);
        characterList.Add(django);
        characterList.Add(johnSmith);

        //We user Console.Writeline to write output to the console
        //Console.WriteLine(johnSmith.ToString());
        int userInput = 0;

        // Create Switch Menu inside while loop w/user input
        while (userInput != 9)
        {
            //Displaying the menu
            Menu.PrintMenu();

            //Store that input into userInput - See Logic.cs
            userInput = Menu.UserChoice();

            //Switch upon the user input
            switch (userInput)
            {   
                //Execute code based on whatever case we enter
                case 1: //Add a character
                Console.WriteLine("This is option 1");
                break;
                
                case 2: //Display all characters
                Console.WriteLine("This is option 2");
                break;

                //If user enters 9 we exit the switch and the program ends
                case 9:
                Console.WriteLine("Goodbye!");    
                return;
            }

        }


        //TODO: Validate User Input with try-catch


    }



}
