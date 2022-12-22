using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Admin
    {
        public int sliderId { get; set; }
        public String ImageTitle { get; set; }
        public String ImageDescription { get; set; }

        public String ImagePath { get; set; }


    }
    public class product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Featured { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}