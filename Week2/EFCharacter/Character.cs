using System;
using System.Collections.Generic;

namespace EFCharacter;

public partial class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short Hitpoints { get; set; }

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<CharacterClass> CharacterClasses { get; set; } = new List<CharacterClass>();
}
