using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using WetterApp.Datenbank;
using WetterApp.Models;

namespace WetterApp.Controllers
{
    public class WetterController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Auswerten(string stadt)
        {
            try
            {
                var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?q=" + stadt + "&appid=a362449158620608045ec05f14294eec&units=metric");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);


                dynamic main = JsonConvert.DeserializeObject(response.Content);
                var wetterlage = main["weather"][0]["main"].Value;


                var temperatur = main["main"]["temp"].Value;



                var nameCity = main["name"].Value;


                var windGesch = main["wind"]["speed"].Value;


                Wetter wetter = new Wetter();



                wetter.WetterLage = wetterlage;
                wetter.Temperatur = Convert.ToDecimal(temperatur);
                wetter.Windgeschwindigkeit = Convert.ToDecimal(windGesch);
                wetter.Name = nameCity;

                return View(wetter);
            }
            catch (Exception)
            {
                return RedirectToAction("index");
            }
            
        }

        public IActionResult listeWetter()
        {
            Data liste = new Data();

            var listeAufrufen = liste.getAll();
            return View(listeAufrufen);
        }

        public IActionResult Speichern(Wetter wetter)
        {
            Data liste = new Data();
            liste.speichern(wetter);
            return RedirectToAction("listeWetter");
        }



    }
}
