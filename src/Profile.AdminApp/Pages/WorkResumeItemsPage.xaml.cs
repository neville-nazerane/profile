using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class WorkResumeItemsPage : ContentPage
{
    private readonly WorkResumeItemViewModel _viewModel;

    public WorkResumeItemsPage()
    {
        BindingContext = _viewModel = new WorkResumeItemViewModel();
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }
}