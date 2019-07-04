using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Messages
{
    public class GetBooks
    {
        public static GetBooks Instance { get; } = new GetBooks();
        private GetBooks()
        {

        }
    }
}
