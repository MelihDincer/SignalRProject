using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TNotificationCountByStatusFalse();
        List<Notification> TGetAllNotificationByFalse();
        void TNotificationChangeToTrue(int id); //Bildirimin türünü true yap. (Okundu)

        void TNotificationChangeToFalse(int id); //Bildirimin türünü true yap. (Okundu)

    }
}
