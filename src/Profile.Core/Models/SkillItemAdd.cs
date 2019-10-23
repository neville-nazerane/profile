using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Core.Models
{
    public class SkillItemAdd
    {

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int? SkillTypeId { get; set; }

    }
}
