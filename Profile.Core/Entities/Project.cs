using System.ComponentModel.DataAnnotations;

namespace Profile.Core.Entities
{
    public class Project
    {

        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        public int Order { get; set; }

        [Url, MaxLength(200)]
        public string Link { get; set; }

        [Url, MaxLength(200)]
        public string SourceCode { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool Enabled { get; set; }

    }
}
