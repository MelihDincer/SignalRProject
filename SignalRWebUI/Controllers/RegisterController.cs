using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.UserName
            };
            var result =await _userManager.CreateAsync(appUser, registerDto.Password); //CreateAsync metodu identity de yeni kullanıcı oluşturmak için kullanılan bir metottur. 2 overloadı mevcuttur. Biz ikinci overloadı kullandık.
            if(result.Succeeded) //result başarılıysa
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
