using System;
using System.Collections.Generic;

namespace WebApplication3.DAL
{
    public partial class Books
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Cost { get; set; }
        public decimal InventoryAmount { get; set; }
    }
}
