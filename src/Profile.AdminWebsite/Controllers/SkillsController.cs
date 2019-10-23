using Microsoft.AspNetCore.Mvc;
using Profile.Core.Models;
using Profile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.AdminWebsite.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillsRepository repository;

        public SkillsController(ISkillsRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index() => View(repository.List(true));

        [HttpGet]
        public IActionResult AddType() => View(new SkillTypeAdd());

        [HttpPost]
        public IActionResult AddType(SkillTypeAdd skillType)
        {
            if (!ModelState.IsValid) return View(skillType);
            repository.Add(skillType);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult EditType(int id) 
            => View(repository.GetSkillType(id));

        [HttpPost]
        public IActionResult EditType(SkillTypeUpdate skillType)
        {
            if (!ModelState.IsValid) return View(skillType);
            repository.Update(skillType);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult AddItem(int typeId) 
            => View(new SkillItemAdd { SkillTypeId = typeId });

        [HttpPost]
        public IActionResult AddItem(SkillItemAdd skillItem)
        {
            if (!ModelState.IsValid) return View(skillItem);
            repository.Add(skillItem);
            return ToIndex;
        }

        public IActionResult Enable(int id)
        {
            repository.Enable(id, true);
            return ToIndex;
        }

        public IActionResult Disable(int id)
        {
            repository.Enable(id, false);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult MoveItemUp(int id)
        {
            repository.MoveItemUp(id);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult MoveItemDown(int id)
        {
            repository.MoveItemDown(id);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult MoveTypeUp(int id)
        {
            repository.MoveTypeUp(id);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult MoveTypeDown(int id)
        {
            repository.MoveTypeDown(id);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            repository.DeleteSkill(id);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult DeleteType(int id)
        {
            repository.DeleteType(id);
            return ToIndex;
        }

        IActionResult ToIndex => RedirectToAction(nameof(Index));

    }
}
