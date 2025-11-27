using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Profile.AdminApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {

        [ObservableProperty]
        private string? key;

        public async Task InitAsync()
        {
            Key = await SecureStorage.GetAsync(Constants.CONTAINER_TOKEN_KEY);
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                SecureStorage.Remove(Constants.CONTAINER_TOKEN_KEY);
            }
            else
            {
                await SecureStorage.SetAsync(Constants.CONTAINER_TOKEN_KEY, Key);
            }
        }

    }
}
