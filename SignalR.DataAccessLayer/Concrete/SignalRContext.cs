using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PBE5IS4\\SQLEXPRESS; initial Catalog=SignalRDb; integrated Security=true");
        }
        
        DbSet<About> Abouts { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<SocialMedia> SocialMedias { get; set; }
        DbSet<Testimonial> Testimonials { get; set; }
    }
}
