using Microsoft.AspNetCore.Mvc;
using AdminDashBoard.Models;
using Newtonsoft.Json;
using System.Text;
using AdminDashBoard.ViewModel;
namespace AdminDashBoard.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<IActionResult>Index()
        {
            var apiUrl = "http://localhost:5000/api/Product/GetAllProduct";
            var response = await _httpClient.GetAsync(apiUrl);
           
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<GetAllProduct>>(jsonContent);
   
                return View(data);
                
            }
            else
            {
                return BadRequest("sorry for this happen");
            }

         
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task Create(Product product)
        {
            
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/api/Product/CreateProduct"); // replace with your API endpoint
                    var json = JsonConvert.SerializeObject(product);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("", content);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Failed to create product: " + response.ReasonPhrase);
                    }
                }
            
        }

        public async Task Delete(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://localhost:5000/api/Product/DeleteProduct/{Id}"); // replace with your API endpoint
                 
            }
        }
    }
}
