using Profile.Core.Entities;
using Profile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Profile.Services
{
    public interface ISkillsRepository
    {

        IEnumerable<SkillType> List(bool showDisabled = false);

        bool DeleteType(int id);

        bool DeleteSkill(int id);

        void MoveItemUp(int id);

        void MoveItemDown(int id);

        void MoveTypeUp(int id);

        void MoveTypeDown(int id);

        SkillType Add(SkillTypeAdd skillType);

        SkillType Update(SkillTypeUpdate skillType);

        SkillItem Add(SkillItemAdd skillItem);

        SkillTypeUpdate GetSkillType(int id);

        void Enable(int id, bool enabled);
    }
}
