using CommunityToolkit.Mvvm.ComponentModel;
using DegenesisCharGen.Enums;
using System.Collections.ObjectModel;

namespace DegenesisCharGen.Models;

public partial class Character : ObservableObject
{
    [ObservableProperty]
    public string name = "";
    [ObservableProperty]
    public int age = 0;
    [ObservableProperty]
    public string sex = "";
    [ObservableProperty]
    public string height = "";
    [ObservableProperty]
    public string weight = "";
    [ObservableProperty]
    public int money = 0;

    [ObservableProperty]
    public Culture? culture = null;
    [ObservableProperty]
    public Cult? cult = null;
    [ObservableProperty]
    public Concept? concept = null;

    public ObservableCollection<Attribute> Attributes { get; set; } =
    [
        new Attribute
        {
            Name = AttributeName.Body,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.Athletics, Attribute = AttributeName.Body, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Brawl, Attribute = AttributeName.Body, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Force, Attribute = AttributeName.Body, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Melee, Attribute = AttributeName.Body, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Stamina, Attribute = AttributeName.Body, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Toughness, Attribute = AttributeName.Body, Max = 2, Value = 0 }
            ]
        },
        new Attribute
        {
            Name = AttributeName.Agility,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.Crafting, Attribute = AttributeName.Agility, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Dexterity, Attribute = AttributeName.Agility, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Navigation, Attribute = AttributeName.Agility, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Mobility, Attribute = AttributeName.Agility, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Projectiles, Attribute = AttributeName.Agility, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Stealth, Attribute = AttributeName.Agility, Max = 2, Value = 0 }
            ]
        },
        new Attribute
        {
            Name = AttributeName.Charisma,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.Arts, Attribute = AttributeName.Charisma, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Conduct, Attribute = AttributeName.Charisma, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Expression, Attribute = AttributeName.Charisma, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Leadership, Attribute = AttributeName.Charisma, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Negotiation, Attribute = AttributeName.Charisma, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Seduction, Attribute = AttributeName.Charisma, Max = 2, Value = 0 }
            ]
        },
        new Attribute
        {
            Name = AttributeName.Intellect,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.ArtifactLore, Attribute = AttributeName.Intellect, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Engineering, Attribute = AttributeName.Intellect, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Focus, Attribute = AttributeName.Intellect, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Legends, Attribute = AttributeName.Intellect, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Medicine, Attribute = AttributeName.Intellect, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Science, Attribute = AttributeName.Intellect, Max = 2, Value = 0 }
            ]
        },
        new Attribute
        {
            Name = AttributeName.Psyche,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.Cunning, Attribute = AttributeName.Psyche, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Deception, Attribute = AttributeName.Psyche, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Domination, Attribute = AttributeName.Psyche, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Faith, Attribute = AttributeName.Psyche, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Reaction, Attribute = AttributeName.Psyche, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Willpower, Attribute = AttributeName.Psyche, Max = 2, Value = 0 }
            ]
        },
        new Attribute
        {
            Name = AttributeName.Instinct,
            Max = 2,
            Value = 0,
            Skills =
            [
                new Skill { Name = SkillName.Empathy, Attribute = AttributeName.Instinct, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Orienteering, Attribute = AttributeName.Instinct, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Perception, Attribute = AttributeName.Instinct, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Primal, Attribute = AttributeName.Instinct, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Survival, Attribute = AttributeName.Instinct, Max = 2, Value = 0 },
                new Skill { Name = SkillName.Taming, Attribute = AttributeName.Instinct, Max = 2, Value = 0 }
            ]
        }
    ];
}
