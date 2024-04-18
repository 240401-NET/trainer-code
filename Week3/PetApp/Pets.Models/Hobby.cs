using System.ComponentModel.DataAnnotations;

namespace Pets.Models;

public class Hobby {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Pet>? Pets { get; set; }
}