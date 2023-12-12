using Microsoft.AspNetCore.Identity;

namespace SignalR.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int> //Default olarak ID'yi string olarak verir. Biz int olarak verdik.
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
