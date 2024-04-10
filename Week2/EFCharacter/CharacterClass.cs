using System;
using System.Collections.Generic;

namespace EFCharacter;

public partial class CharacterClass
{
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public int? CharacterId { get; set; }

    public int? Level { get; set; }

    public virtual Character? Character { get; set; }

    public virtual Class? Class { get; set; }
}
