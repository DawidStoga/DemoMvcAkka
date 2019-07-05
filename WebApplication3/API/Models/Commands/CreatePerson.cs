using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public class CreatePerson
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        [Required]
        public decimal Pesel { get; set; }
    }
}
