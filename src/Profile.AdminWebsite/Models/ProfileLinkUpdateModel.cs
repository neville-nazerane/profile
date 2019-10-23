using Microsoft.AspNetCore.Http;
using Profile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.AdminWebsite.Models
{
    public class ProfileLinkUpdateModel
    {

        public ProfileLinkUpdate Update { get; set; }

        public IFormFile Image { get; set; }

        public ProfileLinkUpdateModel()
        {
            Update = new ProfileLinkUpdate();
        }

    }
}
