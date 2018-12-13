using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Core.Models
{
    public class SkillTypeUpdate
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }
        public bool Enabled { get; set; }
    }
}
