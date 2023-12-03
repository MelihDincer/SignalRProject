using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Contact"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(createContactDto); //createContactDto dan gelen nesne örneğini json türe dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Contact", stringContent); //Ekleme işlemi için PostAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Contact?id={id}"); //Silme işlemi için DeleteAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Contact/GetContact?id={id}"); //Güncelleme sayfasında kategori bilgisini getirmek için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//Jsondan gelen içeriği string formatında okuma
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(updateContactDto); //updateContactDto dan gelen değerleri json türüne dönüştürdük yani serilize ettik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Contact", stringContent); //Güncelleme işlemi için PutAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}