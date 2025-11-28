using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.AdminApp.Utils
{
    public static class MauiUtils
    {

        public static Page CurrentPage => Shell.Current.CurrentPage;

        public static TViewModel? GetCurrentViewModel<TViewModel>()
            where TViewModel: class
            => CurrentPage.BindingContext as TViewModel;

        public static Task DisplayErrorAsync(string message, string cancel = "OK")
            => DisplayAlertAsync("Error", message, cancel);

        public static Task DisplayAlertAsync(string title, string message, string cancel = "OK")
            => CurrentPage.DisplayAlertAsync(title, message, cancel);

        public static Task<bool> DisplayConfirmationAsync(string title, string message, string accept = "Yes", string cancel = "No")
            => CurrentPage.DisplayAlertAsync(title, message, cancel, accept);

    }
}
