using Profile.Core.Entities;
using Profile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Services
{
    public interface IProfileLinkRepository
    {
        IEnumerable<ProfileLink> List(bool showDisabled = false);

        void Enable(int id, bool enabled);

        ProfileLink Add(ProfileLinkAdd link);

        ProfileLinkUpdate GetUpdate(int id);

        ProfileLink Update(ProfileLinkUpdate link);

        void Delete(int id);

        void MoveUp(int id);

        void MoveDown(int id);
    }
}
