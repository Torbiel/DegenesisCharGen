using Avalonia;
using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;
using DegenesisCharGen.Models;
using System.Linq;

namespace DegenesisCharGen.Behaviors;

public class CumulativeRadioButtonBehavior : Behavior<RadioButton>
{
    public static readonly StyledProperty<int> GroupValueProperty =
        AvaloniaProperty.Register<CumulativeRadioButtonBehavior, int>(nameof(GroupValue));

    public int GroupValue
    {
        get => GetValue(GroupValueProperty);
        set => SetValue(GroupValueProperty, value);
    }

    private void OnIsCheckedChanged(bool? isChecked)
    {
        if (isChecked == true)
        {
            var radioButton = AssociatedObject;
            var panel = (Panel)radioButton.Parent;
            var value = GroupValue;

            // Update the bound Attribute or Skill Value
            if (radioButton.DataContext is Attribute attribute)
            {
                attribute.Value = value;
            }
            else if (radioButton.DataContext is Skill skill)
            {
                skill.Value = value;
            }

            // Check all previous radio buttons
            foreach (var child in panel.Children)
            {
                if (child is RadioButton rb && rb != radioButton)
                {
                    var behavior = Interaction.GetBehaviors(rb).OfType<CumulativeRadioButtonBehavior>().FirstOrDefault();
                    if (behavior != null && behavior.GroupValue <= value)
                    {
                        rb.IsChecked = true;
                    }
                }
            }
        }
        else if (isChecked == false)
        {
            var radioButton = AssociatedObject;
            var panel = (Panel)radioButton.Parent;

            // Uncheck all radio buttons
            foreach (var child in panel.Children)
            {
                if (child is RadioButton rb)
                {
                    rb.IsChecked = false;
                }
            }
        }
    }
}