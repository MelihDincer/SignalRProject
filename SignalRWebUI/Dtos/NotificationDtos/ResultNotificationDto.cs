﻿namespace SignalRWebUI.Dtos.NotificationDtos
{
    public class ResultNotificationDto
    {
        public int NotificationID { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
