using Profile.Models;
using Profile.Website.Models;
using System.Net.Http.Json;

namespace Profile.Website.Services
{
    public class DataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task PopulateAllAsync(AllContents contents)
        {
            await foreach (var info in GetPersonalInfoAsync())
            {
                if (info is not null)
                    contents.PersonalInfo.Add(info);
            }

            await foreach (var exp in GetExperienceStatsAsync())
            {
                if (exp is not null)
                    contents.ExperenceStats.Add(exp);
            }

            await foreach (var skill in GetSkillInfoAsync())
            {
                if (skill is not null)
                    contents.Skills.Add(skill);
            }

            await foreach (var work in GetWorkResumeItemsAsync())
            {
                if (work is not null)
                    contents.WorkItems.Add(work);
            }

            await foreach (var education in GetEducationResumeItemsAsync())
            {
                if (education is not null)
                    contents.EducationItems.Add(education);
            }
        }

        public IAsyncEnumerable<ExperenceStat?> GetExperienceStatsAsync()
            => GetDataAsync<ExperenceStat>(Constants.EXPERIENCE_STATS_FILE);

        public IAsyncEnumerable<SkillInfo?> GetSkillInfoAsync()
            => GetDataAsync<SkillInfo>(Constants.SKILL_INFO_FILE);

        public IAsyncEnumerable<ResumeItem?> GetWorkResumeItemsAsync()
            => GetDataAsync<ResumeItem>(Constants.WORK_RESUME_ITEM_FILE);

        public IAsyncEnumerable<ResumeItem?> GetEducationResumeItemsAsync()
            => GetDataAsync<ResumeItem>(Constants.EDUCATION_RESUME_ITEM_FILE);

        public IAsyncEnumerable<PersonalInfo?> GetPersonalInfoAsync()
            => GetDataAsync<PersonalInfo>(Constants.PERSONAL_INFO_FILE);

        IAsyncEnumerable<TModel?> GetDataAsync<TModel>(string fileName)
            => _httpClient.GetFromJsonAsAsyncEnumerable<TModel>(
                                $"{Constants.CONTAINER_NAME}/{fileName}?cache={Guid.NewGuid()}");

    }
}
