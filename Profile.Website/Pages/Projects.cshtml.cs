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
    public class ProjectsModel : PageModel
    {

        public IEnumerable<Project> Projects { get; }

        public ProjectsModel(IProjectsRepository repository)
        {
            Projects = repository.List();
        }

        public void OnGet()
        {

        }
    }
}