using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class ResumeItemsPage : ContentPage
{
    private readonly ResumeItemViewModel _viewModel;

    public ResumeItemsPage()
    {
        BindingContext = _viewModel = new ResumeItemViewModel();
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }
}