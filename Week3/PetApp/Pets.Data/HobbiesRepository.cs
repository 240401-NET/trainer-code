using Microsoft.EntityFrameworkCore;
using Pets.Models;

namespace Pets.Data;

public class HobbiesRepository : IHobbyRepository
{
    private readonly PetsDbContext _context;

    public HobbiesRepository(PetsDbContext context){
        _context = context;
    }

    //Add new hobby entry to the hobby table that references the peds ID
    public IEnumerable<Hobby> AddHobby(Hobby hobby, int id){
        Pet pet = _context.Pets.Find(id);

        if(pet == null){
            throw new ArgumentException("Pet with the given id not found");
        }
        if(pet.Hobbies == null){
            pet.Hobbies = new List<Hobby>();
        }
        // pet.Hobbies ??= new List<Hobby>();
        pet.Hobbies.ToList().Add(hobby);

        _context.SaveChanges();
        return pet.Hobbies;
    }
    
    //Edit hobby by ID
    public void EditHobby(int id, Hobby newHobby){
        Hobby? oldHobby = _context.Hobbies.Find(id);

        if(oldHobby == null){
            throw new ArgumentException("Hobby with the given id is not found");
        }
        
        oldHobby.Name = newHobby.Name ?? oldHobby.Name;
        oldHobby.Description = newHobby.Description ?? oldHobby.Description;
        oldHobby.Pets = newHobby.Pets ?? oldHobby.Pets;
        // _context.Hobbies.Update(nHobby);
        _context.SaveChanges();

    }

    //Delete hobby by ID
    public void DeleteHobby(int id){
        Hobby? hobby = _context.Hobbies.Find(id);

        if(hobby == null){
            throw new ArgumentException("Hobby with the given id is not found");
        }
        _context.Hobbies.Remove(hobby);
        _context.SaveChanges();
    }

    // Get hobby by id
    public Hobby? GetHobbyById(int HobbyId){
        return _context.Hobbies.Find(HobbyId);
    }

    public void Update(Hobby hobby)
    {
        throw new NotImplementedException();
    }
}


