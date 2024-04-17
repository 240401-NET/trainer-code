using Microsoft.AspNetCore.Mvc;
using Pets.Models;
using Pets.Data;
namespace Pets.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HobbyController(PetsRepository petRepository, HobbiesRepository hobbyRepo) : ControllerBase
{
    private readonly PetsRepository _petRepo = petRepository;
    private readonly HobbiesRepository _hobbyRepo = hobbyRepo;

    // Create hobbies of a pet - Room 3 (Kiryl, Adam, Tsering)
    [HttpPost]
    public void AddHobby(Hobby hobby, int id)
    {
      Pet? pet =_petRepo.GetPetById(id) ?? throw new ArgumentException("Pet with id not found.");
      pet.Hobbies = _hobbyRepo.AddHobby(hobby, id);
       
    }

    // Update hobbies of a pet Room 6 (Brian, Eduard)
 [HttpPatch("pets/{id}/hobby/{hobbyid}")]
        public IActionResult EditHobby(int id, int hobbyid, [FromBody] Hobby updatedHobby)
        {
            var pet = _petRepo.GetPetById(id);
            if (pet == null)
            {
                return NotFound("Pet not found");
            }

            var hobby = pet.Hobbies.FirstOrDefault(h => h.Id == hobbyid);
            if (hobby == null)
            {
                return NotFound("Hobby not found for pet");
            }

            hobby.Name = updatedHobby.Name;

            _hobbyRepo.Update(hobby);

            return BadRequest();
        }
    //     // Delete hobbies of a pet ROOM 1 (Kenan, Samat, Jonathan)
    // [HttpDelete]
    // public IActionResult DeleteHobby([FromBody]int petId)
    // {
    //   //if nothing
    //   var pet = _petRepo.GetPetById(petId);
    //   if (pet != null)
    //   {
    //     //
    //     pet.Hobbies.ToList().Clear();
    //     // _petRepo.//save/updat
        
    //     return Ok(pet);
    //   }
    //   return BadRequest();
    // // we dont need this method 
    // }

    // Delete hobbies of a pet ROOM 1 (Kenan, Samat, Jonathan)
    [HttpDelete]
    public IActionResult DeleteHobbyFromDB([FromBody]int hobbyId)
    {
      var hobby = _hobbyRepo.GetHobbyById(hobbyId);
      if (hobby != null)
      {
        _hobbyRepo.DeleteHobby(hobbyId);
        return Ok(hobby);
      }
      return BadRequest();
    }
}