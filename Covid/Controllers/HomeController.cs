using Covid.Models;
using Covid.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var json = await ClientHttp.Get("https://api.covid19api.com/summary");
            var resultContent = json.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Root>(resultContent);


            List<CasosAtivos> casosAtivos = new List<CasosAtivos>();
            for( int i = 0; i < result.Countries.Count(); i++)
            {
                CasosAtivos obj = new CasosAtivos()
                {
                    Pais = result.Countries[i].Country,
                    TotalCasosAtivos = Convert.ToInt32(result.Countries[i].TotalConfirmed) - Convert.ToInt32(result.Countries[i].TotalRecovered)
                };
                casosAtivos.Add(obj);
            }

            var returno = casosAtivos.OrderByDescending(c => c.TotalCasosAtivos).Take(10);

      

               
            return View(returno);
        }
    }
}
