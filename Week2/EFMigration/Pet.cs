public class Pet {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Dob { get; set; }

    public List<Hobby> hobbies { get; set; }
}