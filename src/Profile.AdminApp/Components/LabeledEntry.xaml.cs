namespace Profile.AdminApp.Components;

public partial class LabeledEntry : Grid
{
    public static readonly BindableProperty LabelTextProperty =
                                                BindableProperty.Create(
                                                    nameof(LabelText),
                                                    typeof(string),
                                                    typeof(LabeledEntry),
                                                    propertyChanged: OnLabelTextChanged);

    public static readonly BindableProperty EntryTextProperty =
                                                    BindableProperty.Create(
                                                        nameof(EntryText),
                                                        typeof(string),
                                                        typeof(LabeledEntry),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnEntryTextChanged);

    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }

    public LabeledEntry()
    {
        InitializeComponent();
    }

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        EntryText = e.NewTextValue;
    }

    #region static events

    static void OnLabelTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (LabeledEntry)bindable;
        control.label.Text = (string)newValue;
    }

    static void OnEntryTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (LabeledEntry)bindable;
        control.entry.Text = (string)newValue;
    }

    #endregion
}