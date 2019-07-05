using System;
using System.Collections.Generic;

namespace ApiDemo.Models
{
    public partial class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Pesel { get; set; }
    }
}
