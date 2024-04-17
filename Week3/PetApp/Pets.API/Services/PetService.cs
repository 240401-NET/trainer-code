using Pets.Models;
using Pets.Data;
using System.Text.RegularExpressions;

namespace Pets.Services;

public class PetService : IPetService {

    private readonly IPetRepository _petRepo;

    public PetService(IPetRepository repo) => _petRepo = repo;
    public IEnumerable<Pet> GetAllPets() {
        return _petRepo.GetAllPets();
    }

    public Pet CreateNewPet(Pet pet) {
        // Additional data validation logic that doesn't fit in either layers, you could put in here
        return _petRepo.CreateNewPet(pet);
    }

    public Pet? GetPetById(int id) {
        return _petRepo.GetPetById(id);
    }

    public IEnumerable<Pet> GetPetsByName(string name) {
        // I want the pet name to be longer than 1 character
        // And not start with a number
        name = name.Trim();
		Regex exp = new Regex(@"^(?!^\d)[\w]{2,}$");
        if(exp.IsMatch(name)) {
            return _petRepo.GetPetsByName(name);
        }
        throw new FormatException("Name cannot start with a number and has to be 2 characters or longer");
    }

}