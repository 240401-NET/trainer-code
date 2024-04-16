namespace Pets.Models;

public class Pet {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public DateOnly DoB { get; set; }
    public IEnumerable<Hobby> Hobbies { get; set; }
}