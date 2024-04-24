using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Pets.Data;
using Pets.Models;
using Pets.Services;

namespace Pets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{

    private readonly IPetService _petService;
    private readonly IPetRepository _petRepo;
    private IMemoryCache _memorycache;


    public PetController(IPetService petService, IPetRepository petRepo, IMemoryCache memoryCache){
        this._petService = petService;
        _petRepo = petRepo;
        _memorycache = memoryCache;
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
        // Declare allPets variable to hold data
        IEnumerable<Pet> allPets;
        // First, try to get the data from memoryCache
        // If it is successful, return the data from the cache
        if(_memorycache.TryGetValue("allPets", out allPets)) {
            return allPets;
        }
        else {
            // If we weren't able to retrieve data from memory cache, then go get it from the database
            allPets = _petService.GetAllPets();
            _memorycache.Set("allPets", allPets, new TimeSpan(0, 0, 10));
            return allPets;
        }
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
        return _petService.CreateNewPet(pet);
    }
    
    // Get a Pet By Id - Room 5 (Fatima, Vlada)
    [HttpGet("{id}")]
    public ActionResult<Pet> GetPetById(int id)
    {
          Pet? pet = _petService.GetPetById(id);
          return pet is not null ? pet : NoContent();
    }
    // THIS IS ROOM 2! LEAVE THIS BLOCK ALONE!
    //////////////////////////////////////////////////////////////////////////////
    /// // Search Pets by  - Room 2 (Evan, Dean, Ricardo)
    [HttpGet("search/{name}")]
    public ActionResult<IEnumerable<Pet>> SearchPetsByName(string name)
    {
        try {
            IEnumerable<Pet> pets = _petService.GetPetsByName(name);
            if(!pets.Any())
            {
                return NoContent();
            }
            return Ok(pets); // Please do not edit.
        }
        catch(FormatException e) {
            return BadRequest(e.Message);
        }
    }
    //////////////////////////////////////////////////////////////////////////////
    // Edit Pets - Room 7 (Nakiyyah, Kung)
    [HttpPatch("/pets/{id}")]
    public async Task<ActionResult<Pet>> EditPetById(int id, [FromBody] Pet newPet)
    {
        Pet? updatedPet = await _petRepo.EditPetById(id, newPet);
        
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
        try {
            Pet deletedPet = _petRepo.DeletePet(id)!;
            return deletedPet;
        }
        catch(Exception) {
            return Problem();
        }
    }

    // Get pets with a certain hobbies - If anyone wants this, claim it here - Reluctantly Ricardo will try
    [HttpGet("hobby/{hobbyName}")]
    public ActionResult<IEnumerable<Pet>> GetPetsByHobby(string hobbyName)
    {
        var pets = _petRepo.GetAllPets().Where(p => p.Hobbies.Any(h => h.Name.Equals(hobbyName, StringComparison.OrdinalIgnoreCase))).ToList();
        if (!pets.Any())
        {
            // Credit to Dean for figuring out the NoContent method. <3
            return NoContent(); // thank you <3
        }
        return pets;
    }
}