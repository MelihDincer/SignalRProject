using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusApproved(int id); //Onaylandı
        void BookingStatusCancelled(int id); //İptal edildi
        List<Booking> ApprovalPendingBookings(); //Onay Bekleyen Rezervasyonlar
        List<Booking> ApprovedBookings(); //Onaylanan Rezervasyonlar
        List<Booking> CancelledBookings(); //İptal Edilen Rezervasyonlar
    }
}
