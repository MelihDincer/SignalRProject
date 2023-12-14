using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if(value != null) {
                    QRCodeGenerator createQRCode = new QRCodeGenerator(); //QRCode oluşturma
                    QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q); //QR kodun içeriği
                    using (Bitmap image = squareCode.GetGraphic(10)) //Bellekte oluşturulan QR kodun çizimi - 10px
                    {
                        image.Save(memoryStream, ImageFormat.Png);
                        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                else
                {
                    ViewBag.v = "Boş veri giremezsiniz!";
                }
                
            }
            return View();
        }
    }
}
