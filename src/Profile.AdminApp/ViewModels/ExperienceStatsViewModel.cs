using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Profile.AdminApp.Services;
using Profile.AdminApp.Utils;
using Profile.Models;
using System.Collections.ObjectModel;

namespace Profile.AdminApp.ViewModels
{
    public partial class ExperienceStatsViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<ExperenceStat>? items;

        [ObservableProperty]
        ExperenceStat? toAdd;

        public async Task InitAsync()
        {
            var res = await BlobHttpClient.GetEnumerableAsync<ExperenceStat>(Constants.EXPERIENCE_STATS_FILE);
            if (res is not null)
                Items = new(res);

            ToAdd = GetFresh();
        }

        ExperenceStat GetFresh() => new()
        {
            Label = "Years",
            YearStarted = DateTime.Now.Year,
        };

        [RelayCommand]
        public async Task AddAsync()
        {
            if(Items is null || ToAdd is null) return;

            Items.Add(ToAdd);
            await SaveAsync();

            ToAdd = GetFresh();
        }

        [RelayCommand]
        public async Task DeleteAsync(ExperenceStat item)
        {
            if (Items is null) return;

            Items.Remove(item); 
            await SaveAsync();
        }

        [RelayCommand]
        Task SaveAsync() => BlobHttpClient.SetAsync(Constants.EXPERIENCE_STATS_FILE, Items?.ToArray() ?? []);

    }
}
