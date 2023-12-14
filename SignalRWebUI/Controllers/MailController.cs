using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("SignalR Rezervasyon", "traversal.project@gmail.com"); //Gönderenin mail adresi
            mimeMessage.From.Add(mailboxAddress); //Mailin kimden gideceği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail); //Alıcının mail adresi
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            //İçerik Kısmı
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //Konu
            mimeMessage.Subject = createMailDto.Subject;

            //SmptClient => Simple Mail Transfer Protokol Sunucusu
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); //Gmail için kullanılan mail sağlayıcısı, Türkiye Port Numarası, SSL kullanılsın mı?
            client.Authenticate("traversal.project@gmail.com", "awxcxlkuahtclfwr");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
