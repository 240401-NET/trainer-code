using Pets.Models;

namespace Pets.Data;

public interface IRepository
{
    IEnumerable<Pet> GetAllPets();
    Pet CreateNewPet(Pet pet);
}
