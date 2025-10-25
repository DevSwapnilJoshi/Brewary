using EGlossary.BusinessLayer.IBusinessLayer;
using EGlossary.BusinessLayer.Models;
using EGlossary.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGlossary.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerBuinessLayer _customerBuinessLayer;

        public HomeController(ILogger<HomeController> logger, ICustomerBuinessLayer customerBuinessLayer)
        {
            _logger = logger;
            _customerBuinessLayer = customerBuinessLayer;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel indexViewModel = new();
            indexViewModel.CategoryList = await _customerBuinessLayer.GetLandingDetails();
            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}