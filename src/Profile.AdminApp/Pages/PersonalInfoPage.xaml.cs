using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class PersonalInfoPage : ContentPage
{
    private readonly PersonalInfoViewModel _viewModel;

    public PersonalInfoPage()
    {
        BindingContext = _viewModel = new PersonalInfoViewModel();
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }

}