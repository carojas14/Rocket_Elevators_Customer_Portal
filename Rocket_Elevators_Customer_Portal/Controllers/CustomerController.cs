using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();

        private readonly ILogger<CustomerController> _logger;

        private readonly UserManager<ApplicationUser> _userManager;

        Customer? _customer = new Customer();
        

        public CustomerController(ILogger<CustomerController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender,cert,chain, sslPolicyErrors) => { return true; };
        }
        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            //Get User
            var user = _userManager.GetUserName(User);

            //Buildings by user

            HttpClient userBuilding = new HttpClient(_clientHandler);

            var buildingsList = await userBuilding.GetStringAsync("https://localhost:7234/api/buildings/customer/" + user);

            List<Building>? userBuildings = JsonConvert.DeserializeObject<List<Building>>(buildingsList);
           
            ViewBag.buildings = userBuildings;


            
            //Batteries by user

            HttpClient userBattery = new HttpClient(_clientHandler);

            var batteriesList = await userBattery.GetStringAsync("https://localhost:7234/api/batteries/customer/" + user);

            List<Battery>? userBatteries = JsonConvert.DeserializeObject<List<Battery>>(batteriesList);

            ViewBag.batteries = userBatteries;



            //Columns by user

            HttpClient userColumn = new HttpClient(_clientHandler);

            var columnsList = await userColumn.GetStringAsync("https://localhost:7234/api/columns/customer/" + user);

            List<Column>? userColumns = JsonConvert.DeserializeObject<List<Column>>(columnsList);

            ViewBag.Columns = userColumns;



            //Elevators by user

            HttpClient userElevator = new HttpClient(_clientHandler);

            var elevatorsList = await userElevator.GetStringAsync("https://localhost:7234/api/Elevators/customer/" + user);

            List<Elevator>? userElevators = JsonConvert.DeserializeObject<List<Elevator>>(elevatorsList);

            ViewBag.Elevators = userElevators;


            return View();
        }


        public async Task<IActionResult> Intervention()
        {

            //Get User
            var user = _userManager.GetUserName(User);

            

            //Customer by email

            HttpClient userCustomer = new HttpClient(_clientHandler);

            var customerData = await userCustomer.GetStringAsync("https://localhost:7234/api/customers/" + user);

            _customer = JsonConvert.DeserializeObject<Customer>(customerData);

            ViewBag.Customer = _customer;



            //Buildings by user

            HttpClient userBuilding = new HttpClient(_clientHandler);

            var buildingsList = await userBuilding.GetStringAsync("https://localhost:7234/api/buildings/customer/" + user);

            List<Building>? userBuildings = JsonConvert.DeserializeObject<List<Building>>(buildingsList);

            ViewBag.buildings = userBuildings;



            return View("~/Views/Customer/InterventionForm.cshtml");
        }


        public async Task<IActionResult> BatteryByBuilding(int id)
        {

            //Batteries by building

            HttpClient Battery = new HttpClient(_clientHandler);

            var batteriesList = await Battery.GetStringAsync("https://localhost:7234/api/batteries/building/" + id);

            List<Battery>? Batteries = JsonConvert.DeserializeObject<List<Battery>>(batteriesList);

            ViewBag.batteriesByBuild = Batteries;

            return View("~/Views/Customer/InterventionForm.cshtml");

        }




        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
