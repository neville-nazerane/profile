using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Profile.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Logic
{
    public class AppDbContext : DbContext
    {
        public DbSet<SkillItem> SkillItems { get; set; }

        public DbSet<SkillType> SkillTypes { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProfileLink> ProfileLinks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
    }
}
