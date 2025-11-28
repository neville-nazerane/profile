using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Profile.AdminApp.Models;
using Profile.AdminApp.Services;
using Profile.AdminApp.Utils;
using Profile.Models;
using System.Collections.ObjectModel;

namespace Profile.AdminApp.ViewModels
{
    public partial class ExperienceStatsViewModel : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<ExperenceStatModel>? items;

        [ObservableProperty]
        ExperenceStatModel? toAdd;

        public async Task InitAsync()
        {
            var res = await BlobHttpClient.GetEnumerableAsync<ExperenceStat>(Constants.EXPERIENCE_STATS_FILE);
            if (res is not null)
            {
                var data = res.Select(m =>
                {
                    var d = new ExperenceStatModel();
                    d.FromModel(m);
                    return d;
                }).ToList();

                Items = new(data);
            }

            ToAdd = new();
        }

        [RelayCommand]
        async Task AddAsync()
        {
            if(Items is null || ToAdd is null) return;

            Items.Add(ToAdd);
            await SaveAsync();

            ToAdd = new();
        }

        [RelayCommand]
        void ClearAdd()
        {
            ToAdd = new();
        }

        [RelayCommand]
        async Task DeleteAsync(ExperenceStatModel item)
        {
            if (Items is null) return;

            Items.Remove(item); 
            await SaveAsync();
        }

        [RelayCommand]
        Task SaveAsync()
        {
            if (Items is null) return Task.CompletedTask;
            var data = Items.Select(i => i.ToModel()).ToList();
            return BlobHttpClient.SetAsync(Constants.EXPERIENCE_STATS_FILE, data);
        }
    
    }
}
