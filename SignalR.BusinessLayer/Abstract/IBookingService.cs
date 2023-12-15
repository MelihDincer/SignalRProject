using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusApproved(int id); //Onaylandı
        void TBookingStatusCancelled(int id); //İptal edildi
        List<Booking> TApprovalPendingBookings(); //Onay Bekleyen Rezervasyonlar
        List<Booking> TApprovedBookings(); //Onaylanan Rezervasyonlar
        List<Booking> TCancelledBookings(); //İptal Edilen Rezervasyonlar
    }
}