using Pets.Models;

namespace Pets.Data;

public interface IRepository
{
    IEnumerable<Pet> GetAllPets();
    Pet CreateNewPet(Pet pet);
}

public interface IHobbyRepository
{
    // IEnumerable<Hobby> GetAllHobbies();
    IEnumerable<Hobby> AddHobby(Hobby hobby, int id);
}