using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class EducationResumeItemPage : ContentPage
{
    private readonly EducationResumeItemViewModel _viewModel;

    public EducationResumeItemPage()
    {
        BindingContext = _viewModel = new EducationResumeItemViewModel();
        InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }

}