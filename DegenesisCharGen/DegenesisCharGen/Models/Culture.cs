using DegenesisCharGen.Abstractions;
using DegenesisCharGen.Enums;
using System.Collections.Generic;

namespace DegenesisCharGen.Models;

public class Culture : ICharacteristic
{
    public CultureName? Name { get; set; }
    public string Description { get; set; } = "";
    public List<AttributeName> Attributes { get; set; } = [];
    public List<SkillName> Skills { get; set; } = [];
}
