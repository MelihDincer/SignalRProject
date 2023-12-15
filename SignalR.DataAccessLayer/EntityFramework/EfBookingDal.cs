using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        //Context sınıfında GenericRepository sınıfında bir constructor oluşturmuşturduk. O zaman burada GenericRepository'den miras alıyorsak bu sınıfta da bir constructor oluşturup orada context sınıfını base aldığımız gibi burada da bunu uygulamalıyız. 
        //Yukarıdaki sebepten dolayı aşağıdaki constructor sınıfı oluşturulmuştur.
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public List<Booking> ApprovalPendingBookings()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
        }

        public List<Booking> ApprovedBookings()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").ToList();
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public List<Booking> CancelledBookings()
        {
            using var context = new SignalRContext();
            return context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
        }
    }
}
