using Profile.Models;
using System.Net.Http.Json;

namespace Profile.Website.Services
{
    public class DataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public IAsyncEnumerable<ExperenceStat?> GetExperienceStatsAsync()
            => GetDataAsync<ExperenceStat>(Constants.EXPERIENCE_STATS_FILE);

        public IAsyncEnumerable<SkillInfo?> GetSkillInfoAsync()
            => GetDataAsync<SkillInfo>(Constants.SKILL_INFO_FILE);

        public IAsyncEnumerable<ResumeItem?> GetResumeItemsAsync()
            => GetDataAsync<ResumeItem>(Constants.RESUME_ITEM_FILE);

        IAsyncEnumerable<TModel?> GetDataAsync<TModel>(string fileName)
            => _httpClient.GetFromJsonAsAsyncEnumerable<TModel>(
                                $"{Constants.CONTAINER_NAME}/{fileName}?cache={Guid.NewGuid()}");

    }
}
