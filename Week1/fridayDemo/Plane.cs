

public class Plane : Vehicle, IDriveable
{
    public string make {get; set;}
    public string model {get; set;}
    
    public Plane(){
        make = "Boeing";
        model = "737";
    }

    public void Driving()
    {
        Console.WriteLine("Driving my plane!");
    }

    public override void useFuel(){
        Console.WriteLine("I just killed so many trees.");
    }


}