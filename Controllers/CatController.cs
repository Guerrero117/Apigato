using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ExamenApiGatos.Models;

namespace ExamenApiGatos.Controllers
{
    public class CatController : Controller
    {
        
        private static readonly HttpClient client = new HttpClient();

        public async Task<IActionResult> CatView() 
        {

            var apiKey = "live_nbbqPtxAjvNTr9RZjCZdotutzgl2GsRK13sxUeFkrk7vDubPixazvBoBxuzTP8Ae";
            var url = $"https://Api.thecatapi.com/v1/images/search?api_key={apiKey}";

            var response = await client.GetStringAsync(url);

            var catImages = JsonConvert.DeserializeObject<List<CatImage>>(response);    
            var catImage = catImages.FirstOrDefault();
            
            return View(catImage);
        }
    }
}
