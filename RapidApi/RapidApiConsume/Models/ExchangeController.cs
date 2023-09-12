using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace RapidApiConsume.Models
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=TRY&languagecode=en-us"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fa839c4e67msh93dbcc3119895f0p1b2d76jsn42cb1e24805c" },
                    { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
            
        }
    }
}
