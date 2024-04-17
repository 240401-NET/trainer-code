using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Data;

namespace Pets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{

    private readonly PetsRepository petRepo;

    public PetController(PetsRepository repo){
        this.petRepo = repo;
    }
    /// <summary>
    /// Get All Pets
    /// </summary>
    /// <returns>An IEnumerable of Pets</returns>
    /// <response code="200">Returns a collection of Pets</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Pet> GetPets()
    {
        // This method retrieves all pets from the Pet Repository.
        // Currently, it does not handle null values.
        // If the Pet Repository returns a null value, it will throw a NullReferenceException.
        // However, this is a good place to add logic to handle null values.
        // For now, we will simply return the result of the repository's GetAllPets method.
        return petRepo.GetAllPets();
    }

    /// <summary>
    /// Create a new Pet
    /// </summary>
    /// <param name="pet">The Pet object to be created</param>
    /// <returns>The created Pet object</returns>
    /// <response code="201">Returns the created Pet object</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public Pet CreateNewPet([FromBody] Pet pet)
    {
        // Call the repository to create the new pet
        return petRepo.CreateNewPet(pet);
    }
    
    // Get a Pet By Id - Room 5 (Fatima, Vlada)
    [HttpGet("{id}")]
    public Pet GetPetById(int id)
    {
          var pet = petRepo.GetPetById(id);
          return pet;
    }
    // THIS IS ROOM 2! LEAVE THIS BLOCK ALONE!
    //////////////////////////////////////////////////////////////////////////////
    /// // Search Pets by  - Room 2 (Evan, Dean, Ricardo)
    [HttpGet("search/{name}")]
    public ActionResult<IEnumerable<Pet>> SearchPetsByName(string name)
    {
        var pets = petRepo.GetAllPets().Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        if(!pets.Any())
        {
            return NoContent();
        }
        return pets; // Please do not edit.
    }
    //////////////////////////////////////////////////////////////////////////////
    // Edit Pets - Room 7 (Nakiyyah, Kung)
    [HttpPatch("/pets/{id}")]
    public ActionResult<Pet> EditPetById(int id, [FromBody] Pet newPet)
    {
        Pet? updatedPet = petRepo.EditPetById(id, newPet);
        
        if(updatedPet is null)
        {
            return NoContent();
        }
        else
        {
            return updatedPet;            
        }
    }
    // Delete Pets - Rm 4 (Michael, Val)
    [HttpDelete("/pets/{id}")]
    public ActionResult<Pet?> DeletePet(int id)
    {
        Pet deletedPet = petRepo.DeletePet(id)!;
        return deletedPet;
    }

    // Get pets with a certain hobbies - If anyone wants this, claim it here - Reluctantly Ricardo will try
    [HttpGet("hobby/{hobbyName}")]
    public ActionResult<IEnumerable<Pet>> GetPetsByHobby(string hobbyName)
    {
        var pets = petRepo.GetAllPets().Where(p => p.Hobbies.Any(h => h.Name.Equals(hobbyName, StringComparison.OrdinalIgnoreCase))).ToList();
        if (!pets.Any())
        {
            // Credit to Dean for figuring out the NoContent method. <3
            return NoContent(); // thank you <3
        }
        return pets;
    }
}