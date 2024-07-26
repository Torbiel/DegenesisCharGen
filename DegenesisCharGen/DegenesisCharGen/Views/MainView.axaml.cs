using Avalonia.Controls;
using DegenesisCharGen.ViewModels;

namespace DegenesisCharGen.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}