using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusApproved(int id); //Onaylandı
        void TBookingStatusCancelled(int id); //İptal edildi
    }
}