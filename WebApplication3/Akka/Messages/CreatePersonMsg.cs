using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Messages
{
    public class CreatePersonMsg
    {
        public Person Person { get; private set; }
        public static CreatePersonMsg Instane(Person person) => new CreatePersonMsg { Person = person };
        private CreatePersonMsg() { }
    }
}
