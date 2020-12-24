using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Website.Models
{
    public class SkillItem
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int? SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }

        public int Order { get; set; }

    }
}
