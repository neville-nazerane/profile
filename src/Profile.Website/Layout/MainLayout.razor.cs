using Profile.Website.Models;

namespace Profile.Website.Layout
{
    public partial class MainLayout
    {

        private IEnumerable<SocialData> Socials = 
            [
                new()
                {
                    Class = "github",
                    Icon = "bi-github",
                    Url = "https://github.com/neville-nazerane"
                },
                 new()
                {
                    Class = "linkedin",
                    Icon = "bi-linkedin",
                    Url = "https://www.linkedin.com/in/neville-nazerane"
                }
            ];

    }
}
