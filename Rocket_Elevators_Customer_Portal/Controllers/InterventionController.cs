using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using Rocket_Elevators_Customer_Portal.Models;
using System;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class InterventionController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();

        

        public InterventionController()
        {
            
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        Intervention? _intervention = new Intervention();

        public IActionResult Index()
        {
           
            return View();
        }

       
        [HttpPost]
        public async Task<Intervention> newIntervention(Intervention intervention)
        {
            _intervention = new Intervention();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(intervention), System.Text.Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7234/api/interventions", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _intervention = JsonConvert.DeserializeObject<Intervention>(apiResponse);
                }
            }

            return _intervention;
        }

    }
}
