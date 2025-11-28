using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class SkillInfoPage : ContentPage
{
    private readonly SkillInfoViewModel _viewModel;

    public SkillInfoPage()
    {
        BindingContext = _viewModel = new SkillInfoViewModel();
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }

}