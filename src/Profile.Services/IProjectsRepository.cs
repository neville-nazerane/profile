using Profile.Core.Entities;
using Profile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Services
{
    public interface IProjectsRepository
    {

        IEnumerable<Project> List(bool showDisabled = false);

        Project Add(ProjectAdd project);

        Project Update(ProjectUpdate project);
        ProjectUpdate GetUpdate(int id);

        bool Delete(int id);

        bool MoveUp(int id);

        bool MoveDown(int id);

        void Enable(int id, bool enabled);
    }
}
