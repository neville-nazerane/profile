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
    class ProjectsRepository : IProjectsRepository
    {
        private readonly AppDbContext context;

        public ProjectsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Project Add(ProjectAdd project)
        {
            var toAdd = new Project {
                Title = project.Title,
                Description = project.Description,
                Enabled = project.Enabled,
                Link = project.Link,
                SourceCode = project.SourceCode,
                Order = context.Projects.Select(p => p.Order).DefaultIfEmpty().Max() + 1
            };
            context.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public bool Delete(int id)
        {
            var project = context.Projects.Find(id);
            if (project == null) return false;
            foreach (var p in context.Projects.Where(p => p.Order > project.Order))
                p.Order--;
            context.Projects.Remove(project);
            context.SaveChanges();
            return true;
        }
        
        public bool MoveUp(int id)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id && p.Order > 1);
            if (project == null) return false;
            var above = context.Projects.Single(p => p.Order == project.Order - 1);
            above.Order++;
            project.Order--;
            context.SaveChanges();
            return true;
        }

        public bool MoveDown(int id)
        {
            var project = context.Projects.SingleOrDefault(p => p.Id == id);
            if (project == null) return false;
            var below = context.Projects.SingleOrDefault(p => p.Order == project.Order + 1);
            if (below == null) return false;
            below.Order--;
            project.Order++;
            context.SaveChanges();
            return true;
        }

        public ProjectUpdate GetUpdate(int id)
        {
            var project = context.Projects.Find(id);
            return new ProjectUpdate {
                Id = id,
                Title = project.Title,
                Description = project.Description,
                Enabled = project.Enabled,
                Link = project.Link,
                SourceCode = project.SourceCode
            };
        }

        public IEnumerable<Project> List(bool showDisabled = false)
            => context.Projects.AsTracking().Where(p => showDisabled || p.Enabled).OrderBy(p => p.Order);

        public Project Update(ProjectUpdate project)
        {
            var target = context.Projects.Find(project.Id);
            target.Title = project.Title;
            target.Description = project.Description;
            target.Enabled = project.Enabled;
            target.Link = project.Link;
            target.SourceCode = project.SourceCode;
            context.SaveChanges();
            return target;
        }

        public void Enable(int id, bool enabled)
        {
            var project = context.Projects.Find(id);
            project.Enabled = enabled;
            context.SaveChanges();
        }
    }
}
