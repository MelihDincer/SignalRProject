using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList() 
        { 
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            _notificationService.TAdd(new Notification
            {
                Type = createNotificationDto.Type,
                Icon = createNotificationDto.Icon,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false
            });
            return Ok("Yeni Bildirim Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }

        [HttpPut]
        public IActionResult  UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            _notificationService.TUpdate(new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = updateNotificationDto.Status
            });
            return Ok("Güncelleme başarılı");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("NotificationStatusChangeToFalse")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationChangeToFalse(id);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("Güncelleme yapıldı");
        }
    }
}