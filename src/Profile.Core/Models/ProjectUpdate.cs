using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Profile.Core.Models
{
    public class ProjectUpdate
    {

        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Url, MaxLength(200)]
        public string Link { get; set; }

        [Url, MaxLength(200)]
        public string SourceCode { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool Enabled { get; set; }

    }
}
