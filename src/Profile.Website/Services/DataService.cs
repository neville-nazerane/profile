using Profile.Models;
using System.Net.Http.Json;

namespace Profile.Website.Services
{
    public class DataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public IAsyncEnumerable<ExperenceStat?> GetExperienceStatsAsync()
        {
            var res = _httpClient.GetFromJsonAsAsyncEnumerable<ExperenceStat>(
                                            $"profile-data/experience-stats?cache={Guid.NewGuid()}");

            return res;
        }

        public IAsyncEnumerable<SkillInfo?> GetSkillInfoAsync()
        {
            var res = _httpClient.GetFromJsonAsAsyncEnumerable<SkillInfo>(
                                            $"profile-data/skill-info?cache={Guid.NewGuid()}");

            return res;
        }

    }
}
