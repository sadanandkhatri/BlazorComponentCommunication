using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce1.Models
{
    public class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string BusinessId  { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImg { get; set; }

    }
}