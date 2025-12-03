using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Product/ProductListWithCategory"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Category"); //GetAsync isteğinde bulunduk.
            var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Jsondan gelen içeriği string formatında okuma
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName, //Kullanıcıya gözükecek kısım
                                                Value = x.CategoryID.ToString() //Arka plandaki veri
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(createProductDto); //createProductDto dan gelen nesne örneğini json türe dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Product", stringContent); //Ekleme işlemi için PostAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Product?id={id}"); //Silme işlemi için DeleteAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client1 = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage1 = await client1.GetAsync("https://localhost:7029/api/Category"); //GetAsync isteğinde bulunduk.
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync(); //Jsondan gelen içeriği string formatında okuma
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
            List<SelectListItem> values2 = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName, //Kullanıcıya gözükecek kısım
                                                Value = x.CategoryID.ToString() //Arka plandaki veri
                                            }).ToList();
            ViewBag.v = values2;

            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Product/GetProduct?id={id}"); //Güncelleme sayfasında ürün bilgisini getirmek için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Jsondan gelen içeriği string formatında okuma
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            updateProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(updateProductDto); //createProductDto dan gelen nesne örneğini json türe dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Product", stringContent); //Güncelleme işlemi için PutAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}