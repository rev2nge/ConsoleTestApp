﻿namespace ConsoleTestApp.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} - {Price:C}";
        }
    }
}