using Microsoft.EntityFrameworkCore;
using Profile.Core.Entities;
using Profile.Core.Models;
using Profile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Profile.Logic
{
    class SkillsRepository : ISkillsRepository
    {
        private readonly AppDbContext context;

        public SkillsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public SkillType Add(SkillTypeAdd skillType)
        {
            var toAdd = new SkillType
            {
                Title = skillType.Title,
                Enabled = skillType.Enabled,
                Order = context.SkillTypes.Select(t => t.Order).DefaultIfEmpty().Max() + 1
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public SkillType Update(SkillTypeUpdate skillType)
        {
            var toUpdate = context.SkillTypes.Find(skillType.Id);
            toUpdate.Title = skillType.Title;
            toUpdate.Enabled = skillType.Enabled;
            context.SaveChanges();
            return toUpdate;
        }

        public SkillItem Add(SkillItemAdd skillItem)
        {
            var toAdd = new SkillItem {
                Title = skillItem.Title,
                SkillTypeId = skillItem.SkillTypeId,
                Order = context.SkillItems.Where(t => t.SkillTypeId == skillItem.SkillTypeId)
                                          .Select(t => t.Order).DefaultIfEmpty().Max() + 1
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public bool DeleteSkill(int id)
        {
            var target = context.SkillItems.SingleOrDefault(s => s.Id == id);
            if (target == null) return false;
            foreach (var next in context.SkillItems.Where(s => s.Order > target.Order 
                                                        && s.SkillTypeId == target.SkillTypeId))
                next.Order--;
            context.Remove(target);
            context.SaveChanges();
            return true;
        }

        public bool DeleteType(int id)
        {
            var target = context.SkillTypes.SingleOrDefault(t => t.Id == id);
            if (target == null) return false;
            foreach (var next in context.SkillTypes.Where(t => t.Order > target.Order))
                next.Order--;
            context.Remove(target);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<SkillType> List(bool showDisabled = false)
        {
            var result = context.SkillTypes.Where(t => showDisabled || t.Enabled)
                                .OrderBy(t => t.Order).Include(t => t.Skills).ToList();
            foreach (var type in result)
                type.Skills = type.Skills.OrderBy(s => s.Order);
            return result;
        }

        public void MoveItemDown(int id)
        {
            var target = context.SkillItems.SingleOrDefault(t => t.Id == id);
            if (target == null) return;
            var below = context.SkillItems.SingleOrDefault(t =>
                            t.Order == target.Order + 1 && t.SkillTypeId == target.SkillTypeId);
            if (below == null) return;
            below.Order--;
            target.Order++;
            context.SaveChanges();
        }

        public void MoveItemUp(int id)
        {
            var target = context.SkillItems.SingleOrDefault(t => t.Id == id && t.Order > 1);
            if (target == null) return;
            var above = context.SkillItems.SingleOrDefault(t =>
                            t.Order == target.Order - 1 && t.SkillTypeId == target.SkillTypeId);
            above.Order++;
            target.Order--;
            context.SaveChanges();
        }

        public void MoveTypeDown(int id)
        {
            var target = context.SkillTypes.SingleOrDefault(t => t.Id == id);
            if (target == null) return;
            var below = context.SkillTypes.SingleOrDefault(t => t.Order == target.Order + 1);
            if (below == null) return;
            below.Order--;
            target.Order++;
            context.SaveChanges();
        }

        public void MoveTypeUp(int id)
        {
            var target = context.SkillTypes.SingleOrDefault(t => t.Id == id && t.Order > 1);
            if (target == null) return;
            var above = context.SkillTypes.Single(t => t.Order == target.Order - 1);
            above.Order++;
            target.Order--;
            context.SaveChanges();
        }

        public SkillTypeUpdate GetSkillType(int id)
        {
            var type = context.SkillTypes.Find(id);
            return new SkillTypeUpdate {
                Id = id,
                Title = type.Title,
                Enabled = type.Enabled
            };
        }

        public void Enable(int id, bool enabled)
        {
            var type = context.SkillTypes.Find(id);
            type.Enabled = enabled;
            context.SaveChanges();
        }
    }
}
