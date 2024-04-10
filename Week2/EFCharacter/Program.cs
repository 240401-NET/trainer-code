using EFCharacter;
using Microsoft.EntityFrameworkCore;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string connectionString = File.ReadAllText("connectionstring.txt");

var optionsBuilder = new DbContextOptionsBuilder<FreeCharacterDbContext>();
optionsBuilder.UseSqlServer(connectionString);

FreeCharacterDbContext context = new FreeCharacterDbContext(optionsBuilder.Options);

IEnumerable<Character> characters = context.Characters.Include(c => c.CharacterClasses).ThenInclude(cc => cc.Class).ToList();
Console.WriteLine(characters.Count());
foreach(Character c in characters) {
    Console.WriteLine(c);
    foreach(CharacterClass cc in c.CharacterClasses) {
        Console.WriteLine(cc.Class.Name);
        Console.WriteLine(cc.Level);

    }
}

// Object Initializer
// creates a new instance of the class, using empty constructor
// And assigns values to provided properties
Character newChar = new Character {
    Name = "Kenan",
    Hitpoints = 4332,
    Age = 2
};
// context.Add(newChar);

// Character aurynie = context.Characters.Where(c => c.Name == "Aurynie").FirstOrDefault();

// aurynie.Hitpoints = 200;
// context.Characters.Update(aurynie);

// context.SaveChanges();


// Console.WriteLine(newChar);