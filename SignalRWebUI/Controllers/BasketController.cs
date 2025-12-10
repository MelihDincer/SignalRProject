using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.BasketDto;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = _httpClientFactory.CreateClient();
            //Burada id parametresi MenuTableID değerine karşılık gelmektedir.
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Baskets/BasketListByMenuTableWithProductName?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            int menutableId = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Baskets?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseMessage2 = await client.GetAsync($"https://localhost:7029/api/Baskets/BasketListByMenuTableWithProductName?id={menutableId}");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData2);
                if (values.Count == 0)
                {
                    await client.GetAsync($"https://localhost:7029/api/MenuTables/ChangeMenuTableStatusFalse?id={menutableId}");
                }
                return RedirectToAction("Index", new { id = menutableId });
            }
            return NoContent();
        }
    }
}
