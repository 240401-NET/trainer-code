using Pets.Models;

namespace Pets.Data;

public interface IHobbyRepository
{
    // IEnumerable<Hobby> GetAllHobbies();
    IEnumerable<Hobby> AddHobby(Hobby hobby, int id);
    void EditHobby(int id, Hobby newHobby);
    void DeleteHobby(int id);
    Hobby? GetHobbyById(int HobbyId);
    void Update(Hobby hobby);
}