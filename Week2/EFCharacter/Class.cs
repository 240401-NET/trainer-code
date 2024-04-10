using System;
using System.Collections.Generic;

namespace EFCharacter;

public partial class Class
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CharacterClass> CharacterClasses { get; set; } = new List<CharacterClass>();

    public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
}
