using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Book
    {
        public string Author { get; set; }
        public decimal Cost { get; set; }
        public string Title { get; set; }
        public decimal InventoryAmount { get; set; }
        public Guid Id { get; set; }
    }
}
