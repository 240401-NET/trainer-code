using EFCharacter;
using Microsoft.EntityFrameworkCore;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string connectionString = File.ReadAllText("connectionstring.txt");

var optionsBuilder = new DbContextOptionsBuilder<FreeCharacterDbContext>();
optionsBuilder.UseSqlServer(connectionString);

FreeCharacterDbContext context = new FreeCharacterDbContext(optionsBuilder.Options);

IEnumerable<Character> characters = context.Characters.ToList();
Console.WriteLine(characters.Count());
foreach(Character c in characters) {
    Console.WriteLine(c);
}