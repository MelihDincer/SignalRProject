namespace SignalR.DtoLayer.DiscountDto
{
    public class CreateDiscountDto
    {
        public string Title { get; set; }
        public string Amount { get; set; } //İndirim oranı
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
