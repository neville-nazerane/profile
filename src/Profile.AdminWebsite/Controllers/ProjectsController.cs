using Microsoft.AspNetCore.Mvc;
using Profile.Core.Models;
using Profile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.AdminWebsite.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsRepository repository;

        public ProjectsController(IProjectsRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index() => View(repository.List(true));

        [HttpGet]
        public IActionResult Add() => View(new ProjectAdd());

        [HttpPost]
        public IActionResult Add(ProjectAdd project)
        {
            if (!ModelState.IsValid) return View(project);
            repository.Add(project);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(repository.GetUpdate(id));

        [HttpPost]
        public IActionResult Edit(ProjectUpdate project)
        {
            if (!ModelState.IsValid) return View(project);
            repository.Update(project);
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

        public IActionResult MoveUp(int id)
        {
            repository.MoveUp(id);
            return ToIndex;
        }

        public IActionResult MoveDown(int id)
        {
            repository.MoveDown(id);
            return ToIndex;
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return ToIndex;
        }

        IActionResult ToIndex => RedirectToAction(nameof(Index));

    }
}
