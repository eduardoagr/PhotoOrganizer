using System.Windows.Input;

namespace PhotoOrganizer.Controls;

public partial class TagChip : ContentView {
    public TagChip() {

        InitializeComponent();

        UpdateState();
    }


    public static readonly BindableProperty ChipColorProperty = BindableProperty.Create(
        nameof(ChipColor), typeof(Color), typeof(TagChip));

    public Color ChipColor {
        get => (Color)GetValue(ChipColorProperty);
        set => SetValue(ChipColorProperty, value);
    }


    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(TagChip));

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
        nameof(IsSelected), typeof(bool), typeof(TagChip), false, propertyChanged: OnIsSelectedChanged);

    public bool IsSelected {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(ICommand), typeof(TagChip));

    public ICommand Command {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }


    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter), typeof(object), typeof(TagChip));

    public object CommandParameter {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }



    private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue) {
        if(bindable is TagChip tagChip) {
            tagChip.UpdateState();
        }
    }

    private void UpdateState() {
        ChipBorder.BackgroundColor = IsSelected
            ? Color.FromArgb("#8A3E8A")
            : Colors.Transparent;

        ChipBorder.StrokeThickness = IsSelected
            ? 2
            : 1;
    }



}