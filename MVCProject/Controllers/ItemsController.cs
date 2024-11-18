﻿using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Filters;
using MVCProject.Interfaces;
using MVCProject.Services;

namespace InterviewMVCProject.Controllers
{
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Create(int ownerId)
        {
            ViewBag.PlayerId = ownerId;

            ViewBag.RarityOptions = new List<SelectListItem>
            {
            new SelectListItem { Value = "Common", Text = "Common" },
            new SelectListItem { Value = "Uncommon", Text = "Uncommon" },
            new SelectListItem { Value = "Rare", Text = "Rare" },
            new SelectListItem { Value = "Epic", Text = "Epic"},
            new SelectListItem { Value = "Legendary", Text = "Legendary"}
            };

            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item, int ownerId)
        {
            await _itemService.CreateAsync(item, ownerId);
            return RedirectToAction("Details", "Players", new { id = ownerId });
        }

        [HttpGet]
        [Route("Items/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _itemService.DetailsAsync(id);
            return View(item);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _itemService.GetAllAsync());
        }



    }
}
