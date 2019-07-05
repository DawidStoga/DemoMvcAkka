using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDemo.Messages;
using ApiDemo.Models;
using AutoMapper;
using ApiDemo.ActorProviders;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMapper _mapper;

        /*   There should be only one ActorSystem deployed per application ! */
        /*https://havret.io/akka-net-asp-net-core*/

          private readonly IActorRef _personsManagerActor;
          public PersonsController(PersonsManagerActorProvider PersonsManagerActorProvider, IMapper mapper)
          {
              _personsManagerActor = PersonsManagerActorProvider();
              _mapper = mapper;
          }

          [HttpGet]
          public async Task<IActionResult> Get()
          {
              var Persons = await _personsManagerActor.Ask<IEnumerable<Person>>(GetPersonsMsg.Instance);
              return Ok(Persons);
          }

          [HttpGet("{id}")]
          public async Task<IActionResult> Get(int pesel)
          {
              var result = await _personsManagerActor.Ask(new GetPersonByPeselMsg(pesel));
              switch (result)
              {
                  case PersonMsg Person:
                      return Ok(Person);
                  default:
                      return BadRequest();
              }
          }

          [HttpPost]
          public IActionResult Post([FromBody] CreatePerson command)
          {
              // Tworzenie Akka message

              var person = _mapper.Map<Person>(command);
              var createMsg = CreatePersonMsg.Instane(person);

              /* 1. brak kontroli typów dla messaga. Mozemy przez pomyłkę stworzyć i wysłać nie ten Msg*/
              /* 2. Tell - nie wiemy czy zapis sie powiodl - test with name: errorName*/
            _personsManagerActor.Tell(createMsg);
            return Accepted();
        }

    }
}