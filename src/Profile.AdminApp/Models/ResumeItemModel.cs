using CommunityToolkit.Mvvm.ComponentModel;
using Profile.AdminApp.Utils;
using Profile.Models;

namespace Profile.AdminApp.Models
{
    public partial class ResumeItemModel : ObservableObject, IMapable<ResumeItem>
    {
        [ObservableProperty]
        public string? title;

        [ObservableProperty]
        public string? location;

        [ObservableProperty]
        public string? description;

        [ObservableProperty]
        public string? timeLine;

        public void FromModel(ResumeItem model)
        {
            Title = model.Title;
            Location = model.Location;
            Description = model.Description;
            TimeLine = model.TimeLine;
        }

        public ResumeItem ToModel()
        {
            ArgumentNullException.ThrowIfNull(Title);
            ArgumentNullException.ThrowIfNull(Location);
            ArgumentNullException.ThrowIfNull(Description);
            ArgumentNullException.ThrowIfNull(TimeLine);

            return new ResumeItem
            {
                Title = Title,
                Location = Location,
                Description = Description,
                TimeLine = TimeLine
            };
        }
    }


}
