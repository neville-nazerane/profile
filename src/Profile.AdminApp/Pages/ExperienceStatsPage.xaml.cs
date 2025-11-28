using Profile.AdminApp.ViewModels;

namespace Profile.AdminApp.Pages;

public partial class ExperienceStatsPage : ContentPage
{
    private readonly ExperienceStatsViewModel _viewModel;

    public ExperienceStatsPage()
	{
		BindingContext = _viewModel = new ExperienceStatsViewModel();
		InitializeComponent();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }

}