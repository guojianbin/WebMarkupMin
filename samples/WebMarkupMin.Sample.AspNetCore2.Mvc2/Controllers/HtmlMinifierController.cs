﻿using Microsoft.AspNetCore.Mvc;

using WebMarkupMin.Sample.Logic.Models;
using WebMarkupMin.Sample.Logic.Services;

namespace WebMarkupMin.Sample.AspNetCore2.Mvc2.Controllers
{
	[Route("minifiers/html-minifier")]
	public class HtmlMinifierController : Controller
	{
		private readonly HtmlMinificationService _minificationService;


		public HtmlMinifierController(HtmlMinificationService minificationService)
		{
			_minificationService = minificationService;
		}


		[HttpGet]
		[ResponseCache(CacheProfileName = "CacheCompressedContent5Minutes")]
		public IActionResult Index()
		{
			var model = _minificationService.GetInitializationData();

			return View(model);
		}

		[HttpPost]
		public IActionResult Index(HtmlMinificationViewModel model)
		{
			if (ModelState.IsValid)
			{
				model = _minificationService.Minify(model);

				ModelState.Clear();
			}

			return View(model);
		}
	}
}