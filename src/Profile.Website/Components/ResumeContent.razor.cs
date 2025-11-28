using Microsoft.AspNetCore.Components;
using Profile.Models;

namespace Profile.Website.Components
{
    public partial class ResumeContent
    {

        [Parameter]
        public ICollection<ResumeItem>? Items { get; set; }

    }
}
