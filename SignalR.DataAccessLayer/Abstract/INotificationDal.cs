using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int NotificationCountByStatusFalse(); //Durumu okunmadı olan bildirimlerin sayısı
        List<Notification> GetAllNotificationByFalse(); //Durumu okunmadı olan bildirimlerin listesi
        void NotificationChangeToTrue(int id); //Bildirimin türünü true yap. (Okundu)
        void NotificationChangeToFalse(int id); //Bildirimin türünü false yap. (Okunmadı)
    }
}
