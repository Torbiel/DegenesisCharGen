using DegenesisCharGen.Enums;
using System.Collections.Generic;

namespace DegenesisCharGen.Abstractions;
public interface ICharacteristic
{
    List<AttributeName> Attributes { get; set; }
    List<SkillName> Skills { get; set; }
}
