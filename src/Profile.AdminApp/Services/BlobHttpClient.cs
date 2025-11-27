using Profile.AdminApp.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Profile.AdminApp.Services
{
    public class BlobHttpClient
    {

        static readonly HttpClient client = new();

        static async Task<string?> ConstructUrlAsync(string path)
        {
            var url = await SecureStorage.GetAsync(Constants.CONTAINER_TOKEN_KEY);
            if (url == null)
            {
                await MauiUtils.DisplayErrorAsync("No token set");
                return null;
            }

            var uri = new Uri(url);

            var fullUrl = $"{uri.GetLeftPart(UriPartial.Path)}/{path}{uri.Query}";

            return fullUrl;
        }

        public static async Task<TModel?> GetAsync<TModel>(string blobName)
            where TModel : class, new()
        {
            try
            {
                var url = await ConstructUrlAsync(blobName);
                if (url is null) return null;
                using var res = await client.GetAsync(url);
                res.EnsureSuccessStatusCode();
                using var stream = await res.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<TModel>(stream);
            }
            catch (Exception ex)
            {
                await MauiUtils.DisplayErrorAsync($"Failed to fetch {blobName}. \n {ex}");
                return null;
            }
        }

        public static async Task SetAsync<TModel>(string blobName, TModel model)
            where TModel : class, new()
        {
            try
            {
                var url = await ConstructUrlAsync(blobName);
                if (url is null) return;

                await using var ms = new MemoryStream();
                await JsonSerializer.SerializeAsync(ms, model);
                ms.Position = 0;

                using var content = new StreamContent(ms);
                using var res = await client.PutAsync(url, content);
                res.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                await MauiUtils.DisplayErrorAsync($"Failed to save {blobName}. \n {ex}");
                return;
            }
        }



    }
}
