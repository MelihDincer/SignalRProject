using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id); //Onaylandı
        void BookingStatusCancelled(int id); //İptal edildi
    }
}
