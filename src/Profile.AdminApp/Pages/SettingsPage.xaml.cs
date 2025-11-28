using Profile.AdminApp.ViewModels;
using System.Threading.Tasks;

namespace Profile.AdminApp.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsViewModel _viewModel;

    public SettingsPage()
	{
		BindingContext = _viewModel = new SettingsViewModel();
		InitializeComponent();
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _viewModel.InitAsync();
        base.OnNavigatedTo(args);
    }

}