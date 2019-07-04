using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Messages
{
    public class GetBookById
    {
        public Guid Id { get; set; }
        public GetBookById(Guid id)
        {
            Id = id;
        }

    }
}
