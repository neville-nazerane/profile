using Microsoft.EntityFrameworkCore;
using Profile.Core.Entities;
using Profile.Core.Models;
using Profile.Services;
using System.Collections.Generic;
using System.Linq;

namespace Profile.Logic
{
    class ProfileLinkRepository : IProfileLinkRepository
    {
        private readonly AppDbContext context;

        public ProfileLinkRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ProfileLink Add(ProfileLinkAdd link)
        {
            var toAdd = new ProfileLink {
                Title = link.Title,
                Enabled = link.Enabled,
                IconName = link.IconName,
                URL = link.URL,
                Order = context.ProfileLinks.Select(l => l.Order).DefaultIfEmpty().Max() + 1
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public void Delete(int id)
        {
            var found = context.ProfileLinks.Find(id);
            foreach (var below in context.ProfileLinks.Where(l => l.Order > found.Order))
                below.Order--;
            context.Remove(found);
            context.SaveChanges();
        }

        public void Enable(int id, bool enabled)
        {
            var found = context.ProfileLinks.Find(id);
            found.Enabled = enabled;
            context.SaveChanges();
        }

        public ProfileLinkUpdate GetUpdate(int id)
        {
            var found = context.ProfileLinks.Find(id);
            return new ProfileLinkUpdate {
                Id = found.Id,
                Enabled = found.Enabled,
                IconName = found.IconName,
                Title = found.Title,
                URL = found.URL
            };
        }

        public IEnumerable<ProfileLink> List(bool showDisabled)
            => context.ProfileLinks.AsNoTracking()
                                   .Where(l => showDisabled || l.Enabled)
                                   .OrderBy(l => l.Order).AsEnumerable();

        public void MoveDown(int id)
        {
            var found = context.ProfileLinks.Find(id);
            if (found == null) return;
            var below = context.ProfileLinks.SingleOrDefault(l => l.Order == found.Order + 1);
            if (below == null) return;
            below.Order--;
            found.Order++;
            context.SaveChanges();
        }

        public void MoveUp(int id)
        {
            var found = context.ProfileLinks.SingleOrDefault(l => l.Id == id && l.Order > 1);
            if (found == null) return;
            var above = context.ProfileLinks.Single(l => l.Order == found.Order - 1);
            found.Order--;
            above.Order++;
            context.SaveChanges();
        }

        public ProfileLink Update(ProfileLinkUpdate link)
        {
            var toUpdate = context.ProfileLinks.Find(link.Id);
            toUpdate.Title = link.Title;
            toUpdate.URL = link.URL;
            toUpdate.IconName = link.IconName;
            toUpdate.Enabled = link.Enabled;
            context.SaveChanges();
            return toUpdate;
        }
    }
}
