﻿namespace Ecom.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }
        public string? ImageUrl { get; set; }

        public double Price { get; set; }

        public Product()
        {
        }
    }
}