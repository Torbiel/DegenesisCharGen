using DegenesisCharGen.Abstractions;
using DegenesisCharGen.Enums;
using System.Collections.Generic;

namespace DegenesisCharGen.Models;

public class Cult : ICharacteristic
{
    public CultName Name { get; set; }
    public List<AttributeName> Attributes { get; set; } = [];
    public List<SkillName> Skills { get; set; } = [];
}
