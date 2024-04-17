using Pets.Models;

namespace Pets.Data;

public interface IPetRepository
{
    IEnumerable<Pet> GetAllPets();
    Pet CreateNewPet(Pet pet);
    Pet? DeletePet(int id);
    Pet? GetPetById(int id);

    IEnumerable<Pet> GetPetsByName(string name);
    Task<Pet?> EditPetById(int id, Pet newPet);
}
