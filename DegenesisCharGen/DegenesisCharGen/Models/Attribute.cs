using CommunityToolkit.Mvvm.ComponentModel;
using DegenesisCharGen.Enums;
using System.Collections.ObjectModel;

namespace DegenesisCharGen.Models;

public partial class Attribute : ObservableObject
{
    public AttributeName Name { get; set; }

    [ObservableProperty]
    public int max;

    [ObservableProperty]
    public int value;

    public ObservableCollection<Skill> Skills { get; set; } = [];
}
