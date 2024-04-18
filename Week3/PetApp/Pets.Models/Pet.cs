using System.ComponentModel.DataAnnotations;
namespace Pets.Models;

public class Pet {
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [RegularExpression(@"^(?!^\d)[\w]{2,}$")]
    public string Name { get; set; }
    public string Color { get; set; }
    public DateOnly DoB { get; set; }
    public IEnumerable<Hobby>? Hobbies { get; set; }
}