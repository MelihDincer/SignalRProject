using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Dtos.MessageDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("https://localhost:7029/api/Contact");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();
            //JArray item = JArray.Parse(responseBody);
            //string value = item[0]["location"].ToString();
            //ViewBag.location = value;
            //return View();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7029/api/Contact");
            string jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            ViewBag.location = value[0].Location;
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Message", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Mesajınız alınmıştır.Teşekkür ederiz.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
