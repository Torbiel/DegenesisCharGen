using DegenesisCharGen.Abstractions;
using DegenesisCharGen.Enums;
using System.Collections.Generic;

namespace DegenesisCharGen.Models;

public class Concept : ICharacteristic
{
    public ConceptName Name { get; set; }
    public List<AttributeName> Attributes { get; set; } = [];
    public List<SkillName> Skills { get; set; } = [];
}
