using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Profile.Core.Entities;
using Profile.Services;

namespace Profile.Website.Pages
{
    public class SkillsModel : PageModel
    {

        public IEnumerable<SkillType> SKillTypes { get; set; }

        public SkillsModel(ISkillsRepository skillsRepository)
        {
            SKillTypes = skillsRepository.List();
        }

        public void OnGet()
        {
        }
    }
}