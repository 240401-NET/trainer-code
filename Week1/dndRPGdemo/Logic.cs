namespace dndRPGdemo;

class Logic 
{
    //Prompt the user for character info input
    //Store that input 
    //Use that input to create a Character Object
    //Return that Character object 

    public static void DisplayCharacters(List<Character> characterList){

        foreach(Character character in characterList)
        {
            Console.WriteLine(character.ToString());
        }

    }


/** GenerateUserCharacter
    Ask user for input to generate a character 
*/
    public static Character GenerateUserCharacter(){
        //////////////////////////////////////////////////
        // done by Evan W.
        Character returnCharacter = new();
        Console.WriteLine("What is the name of your character?");
        // maybe wrap up in try block? 
        returnCharacter.name = Console.ReadLine();

        Console.WriteLine($"Your character's name is {returnCharacter.name}." +
            $"\nWhat is {returnCharacter.name}'s age?");

        //integer.parse
        // will need try block
        returnCharacter.age = Convert.ToInt32(Console.ReadLine()); 
        //////////////////////////////////////////////////
        
        //////////////////////////////////////////////////
        //ADAM WAS HERE
        Console.WriteLine($"{returnCharacter.name} is {returnCharacter.age} years old." +
            $"\nWhat job class is {returnCharacter.name}?");

        //check class against list
        returnCharacter.userClass = Console.ReadLine();

        returnCharacter.hitpoints = RandomizeHP();

        Console.WriteLine($"{returnCharacter.name} is a {returnCharacter.age} year old {returnCharacter.userClass}" + 
            $"\n and has {returnCharacter.hitpoints} hitpoints.");

        //////////////////////////////////////////////////

        return returnCharacter;
    }

    /////////////////////////////////
    ///// Evan BACK AT IT AGAIN!
    private static int RandomizeHP()
    {   
        int returnHP = 1;
        Random rng = new();
        returnHP += rng.Next(0, 13);
        
        
        return returnHP;

    }
    /////////////////////////////////
}