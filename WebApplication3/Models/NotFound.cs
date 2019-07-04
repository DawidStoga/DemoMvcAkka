using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class NotFound
    {
        public static NotFound Instance { get; } = new NotFound();

        private NotFound()
        {

        }
    }
}
