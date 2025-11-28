using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Profile.AdminApp.Models;
using Profile.AdminApp.Services;
using Profile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Profile.AdminApp.Utils
{
    public abstract partial class CrudViewModelBase<TModel, TLocalModel> : ObservableObject
        where TModel : class
        where TLocalModel : IMapable<TModel>, new()
    {
        private readonly string _fileName;

        [ObservableProperty]
        ObservableCollection<TLocalModel>? items;

        [ObservableProperty]
        TLocalModel? toAdd;

        protected CrudViewModelBase(string fileName)
        {
            _fileName = fileName;
        }

        public async Task InitAsync()
        {
            var res = await BlobHttpClient.GetEnumerableAsync<TModel>(_fileName);
            if (res is not null)
            {
                var data = res.Select(m =>
                {
                    var d = new TLocalModel();
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
            if (Items is null || ToAdd is null) return;

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
        async Task DeleteAsync(TLocalModel item)
        {
            if (Items is null) return;

            var confirm = await MauiUtils.DisplayConfirmationAsync("Delete?", "Are you sure you want to delete this record?");
            if (confirm)
            {
                Items.Remove(item);
                await SaveAsync();
            }

        }

        [RelayCommand]
        Task SaveAsync()
        {
            if (Items is null) return Task.CompletedTask;
            var data = Items.Select(i => i.ToModel()).ToList();
            return BlobHttpClient.SetAsync(_fileName, data);
        }

    }
}
