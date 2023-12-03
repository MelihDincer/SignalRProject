using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FeatureDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Feature"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(createFeatureDto); //createFeatureDto dan gelen nesne örneğini json türe dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Feature", stringContent); //Ekleme işlemi için PostAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Feature?id={id}"); //Silme işlemi için DeleteAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Feature/GetFeature?id={id}"); //Güncelleme sayfasında kategori bilgisini getirmek için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//Jsondan gelen içeriği string formatında okuma
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto); //updateFeatureDto dan gelen değerleri json türüne dönüştürdük yani serilize ettik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Feature", stringContent); //Güncelleme işlemi için PutAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}