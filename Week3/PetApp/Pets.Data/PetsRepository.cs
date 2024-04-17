using Microsoft.EntityFrameworkCore;
using Pets.Models;

namespace Pets.Data;

public class PetsRepository : IPetRepository
{
    private readonly PetsDbContext _context;
    public PetsRepository(PetsDbContext context) {
        _context = context;
    }

    // Create
    public Pet CreateNewPet(Pet pet) {
        _context.Pets.Add(pet);
        _context.SaveChanges();

        return pet;
    }

    // Retrieve
    public IEnumerable<Pet> GetAllPets() {
        return _context.Pets.Include(p=> p.Hobbies).ToList();
    }

    // Update

    // Delete

    public Pet? DeletePet(int id)
    {
        var petToDelete = GetPetById(id);
        try
        {
            // Pet? pet = _context.Pets.Find(id);
            if (petToDelete != null)
            {
                _context.Pets.Remove(petToDelete);
                _context.SaveChanges();
                // _context.ChangeTracker.Clear();
                return petToDelete;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

        return petToDelete;
    }


    //Get Pet by Id
    public Pet? GetPetById(int id){
        return _context.Pets.Find(id);
    }

    public async Task<Pet?> EditPetById(int id, Pet newPet)
    {
        Pet oldPet = GetPetById(id);
        
        if(oldPet != null)
        {
            oldPet.Name = newPet.Name ?? oldPet.Name;
            oldPet.Color = newPet.Color ?? oldPet.Color;
            oldPet.DoB = oldPet.DoB.Equals(newPet.DoB) ? oldPet.DoB : newPet.DoB;
            oldPet.Hobbies = newPet.Hobbies ?? oldPet.Hobbies;
            await _context.SaveChangesAsync();
            return oldPet;
        }

        return null;       
    }

    public IEnumerable<Pet> GetPetsByName(string name) {
        return _context.Pets.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
 }
