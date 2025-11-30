using Profile.Models;

namespace Profile.Website.Models
{
    public class AllContents
    {

        public ICollection<ExperenceStat> ExperenceStats { get; } = [];
        public ICollection<PersonalInfo> PersonalInfo { get; } = [];
        public ICollection<SkillInfo> Skills { get; } = [];
        public ICollection<ResumeItem> WorkItems { get; } = [];
        public ICollection<ResumeItem> EducationItems { get; } = [];

    }
}
