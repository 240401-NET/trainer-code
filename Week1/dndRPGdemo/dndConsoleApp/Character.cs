namespace dndRPGdemo;

public class Character 
{   // Fields/properties
    //shorthand to avoid getters and setters
    public string? name {get; set;}
    public string? userClass {get;set;}
    public int? age {get; set;}
    public int? hitpoints {get;set;}

    //Constructors
    
    //No argument constructor
    public Character() {}

    //Constructor with arguments
    public Character(string name, string userClass, int a, int h){
        this.name = name;
        this.userClass = userClass;
        age = a;
        hitpoints = h;
    }

    //Overriding a method, in this case toString()
    public override string ToString()
    {
        return "Name: " + name + "\nClass: " + userClass + "\nAge: " + age + "\nHitpoints: " + hitpoints;
    }

    //TODO: Create a battle HP comparator function
    //we want to take in, two values (hitpoints on a character) and return a 1 or a 2 
    //depending on which value is higher 
    //add RNG to handle same HP characters
    public static int SimpleBattle(int characterOneHP, int characterTwoHP)
    {
        if(characterOneHP > characterTwoHP){
            return 1;
        }else if(characterTwoHP > characterOneHP){
            return 2;
        }else{
            //TODO: Use RNG to resolve same HP battles
            return 0;
        }

    }






}