using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Messages
{
    public class GetPersonsMsg
    {
        public static GetPersonsMsg Instance { get; } = new GetPersonsMsg();
        private GetPersonsMsg()
        {

        }
    }
}
