
public abstract class Vehicle 
{   
    //Non abstract method
    public void makeNoise()
    {
        Console.WriteLine("vroom vroom");
    }

    //abstract method
    public abstract void useFuel();
}