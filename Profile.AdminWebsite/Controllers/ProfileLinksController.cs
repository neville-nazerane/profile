using Common.Azure.Blob;
using Microsoft.AspNetCore.Mvc;
using Profile.AdminWebsite.Models;
using Profile.Core.Entities;
using Profile.Core.Models;
using Profile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.AdminWebsite.Controllers
{
    public class ProfileLinksController : Controller
    {
        private readonly IProfileLinkRepository repository;
        private readonly IBlobManager blobManager;

        const string iconContainer = "profile-icons";

        public ProfileLinksController(IProfileLinkRepository repository, IBlobManager blobManager)
        {
            this.repository = repository;
            this.blobManager = blobManager;
        }

        public IActionResult Index() => View(repository.List(true));

        [HttpGet]
        public IActionResult Add() => View(new ProfileLinkAddModel());

        [HttpPost]
        public async Task<IActionResult> Add(ProfileLinkAddModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Image?.Length > 0)
                model.Add.IconName = iconContainer + "/" + await blobManager.AddToContainerAsync(iconContainer, model.Image);
            repository.Add(model.Add);
            return ToIndex;
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(new ProfileLinkUpdateModel {
            Update = repository.GetUpdate(id)
        });

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileLinkUpdateModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Image?.Length > 0) 
                model.Update.IconName = iconContainer + "/" + await blobManager.AddToContainerAsync(iconContainer, model.Image);
            repository.Update(model.Update);
            return ToIndex;
        }

        public IActionResult Delete(int id)
        {
            repository.Delete(id);
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

        IActionResult ToIndex => RedirectToAction(nameof(Index));

    }
}
