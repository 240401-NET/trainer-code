using Pets.Models;

namespace Pets.Data;

public class PetsRepository : IRepository
{
    private readonly PetsDbContext _context;
    public PetsRepository(PetsDbContext context) {
        _context = context;
    }
    public IEnumerable<Pet> GetAllPets() {
        return _context.Pets.ToList();
    }

    public Pet CreateNewPet(Pet pet) {
        _context.Pets.Add(pet);
        _context.SaveChanges();

        return pet;
    }
 }
