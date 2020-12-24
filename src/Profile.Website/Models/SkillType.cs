using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Profile.Website.Models
{
    public class SkillType
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public IEnumerable<SkillItem> Skills { get; set; }

        public int Order { get; set; }

        public bool Enabled { get; set; }

        public SkillType()
        {
            Enabled = true;
        }

    }
}
