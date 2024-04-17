using Pets.Models;

namespace Pets.Services;

public interface IPetService {
    IEnumerable<Pet> GetAllPets();

    Pet CreateNewPet(Pet pet);

    Pet? GetPetById(int id);

    IEnumerable<Pet> GetPetsByName(string name);
}