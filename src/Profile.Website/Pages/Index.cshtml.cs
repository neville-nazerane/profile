using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Profile.Website.Models;

namespace Profile.Website.Pages
{
    public class IndexModel : PageModel
    {

        public string blobUrl = "https://nevilleimages.blob.core.windows.net";

        public IEnumerable<ProfileLink> ProfileLinks { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public IndexModel()
        {
            ProfileLinks = new ProfileLink[]
            { 
                new ProfileLink { 
                    Title = "GitHub",
                    URL = "https://github.com/neville-nazerane",
                    IconName = "profile-icons/2b48b22fcc8b4e90bd47e01d5cba51a3.png"
                },
                new ProfileLink
                {
                    Title = "Stackoverflow",
                    URL = "https://stackoverflow.com/users/991609",
                    IconName = "profile-icons/b80b9d9dc1854e1e9963760715aada39.png"
                },
                new ProfileLink
                {
                    Title = "LinkedIn",
                    URL = "https://www.linkedin.com/in/neville-nazerane",
                    IconName = "profile-icons/98f7973facc44a7d9cf3245e6918350d.png"
                },
                new ProfileLink
                {
                    Title = "Nuget",
                    URL = "https://www.nuget.org/profiles/Neville.Nazerane",
                    IconName = "profile-icons/da70f5f6070241b3bb36d03c2076982a.png"
                },
                new ProfileLink
                {
                    Title = "Stackoverflow CV",
                    URL = "https://stackoverflow.com/story/nevillenazerane",
                    IconName = "profile-icons/e476b6c53a114127befee3673d4b8485.png"
                }
            };

            Projects = new Project[] 
            { 
                new Project
                {
                    Title = "Nuget Documentation",
                    Description = "Documentation for recent nuget packages.",
                    Link = null,
                    SourceCode = "https://github.com/neville-nazerane/docs"
                },
                new Project
                {
                    Title = "AutoSite",
                    Description = "AI based app that reads, interprets and predicts data types and field names from an images. The output can then be used to generate a full stack website with database and UI.",
                    Link = null,
                    SourceCode = "https://github.com/neville-nazerane/autosite"
                },
                new Project
                {
                    Title = "Profile",
                    Description = "The current website",
                    Link = null,
                    SourceCode = "https://github.com/neville-nazerane/profile"
                }
            };
        }

        //public IndexModel(IProfileLinkRepository profileLinkRepository, IProjectsRepository projectsRepository)
        //{
        //    ProfileLinks = profileLinkRepository.List();
        //    Projects = projectsRepository.List();
        //}

        //public void OnGet()
        //{
        //}
    }
}
