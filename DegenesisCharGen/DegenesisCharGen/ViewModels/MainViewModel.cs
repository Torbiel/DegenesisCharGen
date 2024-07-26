using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DegenesisCharGen.Enums;
using DegenesisCharGen.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DegenesisCharGen.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private Character character = new();

    [ObservableProperty]
    private int maxAttributePoints = 10;
    [ObservableProperty]
    private int attributePoints = 10;
    [ObservableProperty]
    private bool hasAttributePoints;
    [ObservableProperty]
    private int maxSkillPoints = 28;
    [ObservableProperty]
    private int skillPoints = 28;
    [ObservableProperty]
    private bool hasSkillPoints;

    public ObservableCollection<Culture> Cultures { get; set; } = [];
    public ObservableCollection<Cult> Cults { get; set; } = [];
    public ObservableCollection<Concept> Concepts { get; set; } = [];

    public MainViewModel()
    {
        ExportToPdfCommand = new RelayCommand(ExportToPdf);
        Initialize3Cs();

        HasAttributePoints = AttributePoints > 0;
        HasSkillPoints = SkillPoints > 0;

        foreach (var attribute in Character.Attributes)
        {
            attribute.PropertyChanged += OnAttributePropertyChanged;
            foreach (var skill in attribute.Skills)
            {
                skill.PropertyChanged += OnSkillPropertyChanged;
            }
        }
    }

    private void OnAttributePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Attribute.Value))
        {
            AttributePoints = MaxAttributePoints - Character.Attributes.Sum(a => a.Value) + 6;
            HasAttributePoints = AttributePoints > 0;
        }
    }

    private void OnSkillPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Skill.Value))
        {
            SkillPoints = MaxSkillPoints - Character.Attributes.Sum(a => a.Skills.Sum(s => s.Value));
            HasSkillPoints = SkillPoints > 0;
        }
    }

    private void Initialize3Cs()
    {
        Cultures =
        [
            new Culture
            {
                Name = CultureName.Borca,
                Description = "",
                Attributes = [AttributeName.Agility, AttributeName.Instinct],
                Skills = [SkillName.Toughness, SkillName.ArtifactLore, SkillName.Engineering, SkillName.Crafting, SkillName.Survival]
            },
            new Culture
            {
                Name = CultureName.Franka,
                Description = "",
                Attributes = [AttributeName.Charisma, AttributeName.Instinct],
                Skills = [SkillName.Stamina, SkillName.Stealth, SkillName.Negotiation, SkillName.Faith, SkillName.Willpower, SkillName.Deception]
            },
            new Culture
            {
                Name = CultureName.Pollen,
                Description = "",
                Attributes = [AttributeName.Body, AttributeName.Instinct],
                Skills = [SkillName.Melee, SkillName.Stamina, SkillName.Legends, SkillName.Survival, SkillName.Empathy]
            },
            new Culture
            {
                Name = CultureName.Balkhan,
                Description = "",
                Attributes = [AttributeName.Body, AttributeName.Psyche],
                Skills = [SkillName.Brawl, SkillName.Force, SkillName.Leadership, SkillName.Reaction, SkillName.Empathy]
            },
            new Culture
            {
                Name = CultureName.Hybrispania,
                Description = "",
                Attributes = [AttributeName.Intellect, AttributeName.Agility],
                Skills = [SkillName.Melee, SkillName.Mobility, SkillName.Stealth, SkillName.Medicine, SkillName.Orienteering]
            },
            new Culture
            {
                Name = CultureName.Purgare,
                Description = "",
                Attributes = [AttributeName.Charisma, AttributeName.Psyche],
                Skills = [SkillName.Conduct, SkillName.Legends, SkillName.Faith, SkillName.Willpower, SkillName.Domination, SkillName.Taming]
            },
            new Culture
            {
                Name = CultureName.Africa,
                Description = "",
                Attributes = [AttributeName.Intellect, AttributeName.Body],
                Skills = [SkillName.Athletics, SkillName.Brawl, SkillName.Expression, SkillName.Medicine, SkillName.Reaction]
            }
        ];

        Cults =
        [
            new Cult { Name = CultName.Spitalians },
            new Cult { Name = CultName.Chroniclers },
            new Cult { Name = CultName.Hellvetics },
            new Cult { Name = CultName.Judges },
            new Cult { Name = CultName.Clanners },
            new Cult { Name = CultName.Scrappers },
            new Cult { Name = CultName.Neolibyans },
            new Cult { Name = CultName.Scourgers },
            new Cult { Name = CultName.Anubians },
            new Cult { Name = CultName.Jehammedans },
            new Cult { Name = CultName.Apocalyptics },
            new Cult { Name = CultName.Anabaptists },
            new Cult { Name = CultName.Palers },
        ];

        Concepts =
        [
            new Concept { Name = ConceptName.TheAdventurer },
            new Concept { Name = ConceptName.TheCreator },
            new Concept { Name = ConceptName.TheMentor },
            new Concept { Name = ConceptName.TheMartyr },
            new Concept { Name = ConceptName.TheRuler },
            new Concept { Name = ConceptName.TheSeeker },
            new Concept { Name = ConceptName.TheHealer },
            new Concept { Name = ConceptName.TheTraditionalist },
            new Concept { Name = ConceptName.TheMediator },
            new Concept { Name = ConceptName.TheHermit },
            new Concept { Name = ConceptName.TheHeretic },
            new Concept { Name = ConceptName.TheConqueror },
            new Concept { Name = ConceptName.TheAbomination },
            new Concept { Name = ConceptName.TheDestroyer },
            new Concept { Name = ConceptName.TheChosen },
            new Concept { Name = ConceptName.TheDefiler },
            new Concept { Name = ConceptName.TheProtector },
            new Concept { Name = ConceptName.TheVisionary },
            new Concept { Name = ConceptName.TheZealot },
            new Concept { Name = ConceptName.TheDisciple },
            new Concept { Name = ConceptName.TheRighteous },
            new Concept { Name = ConceptName.TheTraveler },
        ];
    }

    public IRelayCommand ExportToPdfCommand { get; }

    private void ExportToPdf()
    {
        var templatePath = Path.Combine("D:\\Programowanie\\DegenesisCharGen\\DegenesisCharGen\\DegenesisCharGen\\Assets", "template.pdf");
        var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        var filename = Path.Combine(documentsPath, "CharacterData.pdf");

        File.Copy(templatePath, filename, true);

        var document = PdfReader.Open(filename, PdfDocumentOpenMode.Modify);
        var page = document.Pages[0];

        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12, XFontStyle.Regular);

        gfx.DrawString($"{Character.Name}", font, XBrushes.Black, new XPoint(100, 100));

        document.Save(filename);
    }
}
