using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Messages
{
    public class PersonMsg
    {
        public Person Person { get; private set; }
        public static PersonMsg Instane(Person person) => new PersonMsg { Person = person };
        private PersonMsg() { }
    }
}
