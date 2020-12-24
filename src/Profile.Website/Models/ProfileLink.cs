using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Website.Models
{
    public class ProfileLink
    {

        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Required, Url, MaxLength(100)]
        public string URL { get; set; }

        [MaxLength(50)]
        public string IconName { get; set; }

        public bool Enabled { get; set; }

        public int Order { get; set; }

    }
}
