using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Diagnostics;



namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class HomeController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();

        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IActionResult> Index()
        {
            //Get User
            var user = _userManager.GetUserName(User);

            //Interventions by user

            HttpClient userIntervention = new HttpClient(_clientHandler);

            var interventionsList = await userIntervention.GetStringAsync("https://localhost:7234/api/interventions/customer/" + user);

            List<Intervention>? userInterventions = JsonConvert.DeserializeObject<List<Intervention>>(interventionsList);

            ViewBag.interventions = userInterventions;

            return View();
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