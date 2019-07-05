using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Messages
{
    public class GetPersonByPeselMsg
    {
        public int Pesel { get; set; }
        public GetPersonByPeselMsg(int pesel)
        {
            Pesel = pesel;
        }

    }
}
