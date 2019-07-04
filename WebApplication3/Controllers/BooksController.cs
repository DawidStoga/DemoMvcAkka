using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Bookstore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Messages;
using WebApplication3.Models;
using static WebApplication3.Startup;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IActorRef _booksManagerActor;
        public BooksController(BooksManagerActorProvider booksManagerActorProvider)
        {
            _booksManagerActor = booksManagerActorProvider();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _booksManagerActor.Ask<IEnumerable<Book>>(GetBooks.Instance);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _booksManagerActor.Ask(new GetBookById(id));
            switch (result)
            {
                case Book book:
                    return Ok(book);
                default:
                    return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBook command)
        {
            _booksManagerActor.Tell(command);
            return Accepted();
        }

    }
}