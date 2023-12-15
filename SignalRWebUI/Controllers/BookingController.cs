using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Onay Bekleyen Rezervasyonlar
        public async Task<IActionResult> ApprovalPendingBookingList()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Booking/ApprovalPendingBookingList"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        //Onaylanan Rezervasyonlar
        public async Task<IActionResult> ApprovedBookingList()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Booking/ApprovedBookingList"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        //İptal Edilen Rezervasyonlar
        public async Task<IActionResult> CancelledBookingList()
        {
            var client = _httpClientFactory.CreateClient(); //Client(istemci) oluşturuldu.
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Booking/CancelledBookingList"); //Listeleme işlemi için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Response'dan gelen veriyi jsonData değişkenine atadık.
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(createBookingDto); //createBookingDto dan gelen nesne örneğini json türe dönüştürdük.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Booking", stringContent); //Ekleme işlemi için PostAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("ApprovalPendingBookingList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Booking?id={id}"); //Silme işlemi için DeleteAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("ApprovalPendingBookingList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            List<SelectListItem> bookingDescription = new List<SelectListItem>();
            bookingDescription.Add(new SelectListItem { Text = "Rezervasyon Onaylandı", Value = "Rezervasyon Onaylandı" });
            bookingDescription.Add(new SelectListItem { Text = "Rezervasyon İptal Edildi", Value = "Rezervasyon İptal Edildi" });
            ViewBag.description = bookingDescription;

            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Booking/GetBooking?id={id}"); //Güncelleme sayfasında kategori bilgisini getirmek için GetAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//Jsondan gelen içeriği string formatında okuma
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData); //Json türündeki bu veriyi deserialize ederek tabloda görüntüleyebileceğimiz bir türe dönüştürdük.
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturduk.
            var jsonData = JsonConvert.SerializeObject(updateBookingDto); //updateBookingDto dan gelen değerleri json türüne dönüştürdük yani serilize ettik.
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); //İçeriğimizin dönüşümü için StringContent sınıfından bir nesne türetip üçüncü overloadını bu şekilde kullandık. (içerik, türkçe karakteri destekle, medya türü)
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Booking", stringContent); //Güncelleme işlemi için PutAsync isteğinde bulunduk.
            if (responseMessage.IsSuccessStatusCode) //Başarılı durum kodu dönerse
            {
                return RedirectToAction("ApprovalPendingBookingList");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7029/api/Booking/BookingStatusApproved?id={id}");
            return RedirectToAction("ApprovedBookingList");
        }

        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7029/api/Booking/BookingStatusCancelled?id={id}");
            return RedirectToAction("CancelledBookingList");
        }
    }
}
