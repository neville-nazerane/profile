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
    public class IndexModel : PageModel
    {

        public IEnumerable<ProfileLink> ProfileLinks { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IndexModel(IProfileLinkRepository profileLinkRepository, IProjectsRepository projectsRepository)
        {
            ProfileLinks = profileLinkRepository.List();
            Projects = projectsRepository.List();
        }

        public void OnGet()
        {
        }
    }
}