using Profile.Models;
using System.Net.Http.Json;

namespace Profile.Website.Services
{
    public class DataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public IAsyncEnumerable<ExperenceStat?> GetExperienceStatsAsync()
            => _httpClient.GetFromJsonAsAsyncEnumerable<ExperenceStat>(
                                            $"profile-data/experience-stats?cache={Guid.NewGuid()}");

        public IAsyncEnumerable<SkillInfo?> GetSkillInfoAsync()
            => _httpClient.GetFromJsonAsAsyncEnumerable<SkillInfo>(
                                            $"profile-data/skill-info?cache={Guid.NewGuid()}");

    }
}
