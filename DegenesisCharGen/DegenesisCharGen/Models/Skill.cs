using CommunityToolkit.Mvvm.ComponentModel;
using DegenesisCharGen.Enums;

namespace DegenesisCharGen.Models;

public partial class Skill : ObservableObject
{
    public SkillName Name { get; set; }
    public AttributeName Attribute { get; set; }

    [ObservableProperty]
    public int max;

    [ObservableProperty]
    public int value;
}
