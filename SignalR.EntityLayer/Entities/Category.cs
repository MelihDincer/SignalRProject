﻿namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        
        //Bire çok ilişki
        public List<Product> Products { get; set; }
    }
}
