using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public class NotFoundMsg
    {
        public static NotFoundMsg Instance { get; } = new NotFoundMsg();

        private NotFoundMsg()
        {

        }
    }
}
