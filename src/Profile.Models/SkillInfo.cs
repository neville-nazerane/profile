namespace Profile.Models
{
    public class SkillInfo
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public required int Percentage { get; set; }

        public string LevelLabel => Percentage switch
        {
            <= 25 => "Beginner",
            <= 50 => "Intermediate",
            <= 85 => "Advanced",
            _ => "Expert"
        };

    }
}
