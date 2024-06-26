﻿using System;
using System.Collections.Generic;

namespace EFCharacter;

public partial class Feature
{
    public int Id { get; set; }

    public int? ClassId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Class? Class { get; set; }
}
