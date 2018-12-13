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
    public class LinksModel : PageModel
    {

        public IEnumerable<ProfileLink> Profiles { get; set; }

        public LinksModel(IProfileLinkRepository repository)
        {
            Profiles = repository.List();
        }

        public void OnGet()
        {
        }
    }
}