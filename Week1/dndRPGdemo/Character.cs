namespace dndRPGdemo;

class Character 
{   // Fields/properties
    //shorthand to avoid getters and setters
    public string name {get; set;}
    public string userClass {get;set;}
    public int age {get; set;}
    public int hitpoints {get;set;}

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
    //TODO: Change to use string interpolation
    public override string ToString()
    {
        return "Name: " + name + "\nClass: " + userClass + "\nAge: " + age + "\nHitpoints: " + hitpoints;
    }






}