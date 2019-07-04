using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.DAL;
using WebApplication3.Extensions;
using WebApplication3.Messages;
using WebApplication3.Models;

namespace WebApplication3.Akka
{
    public class BookManagerActor: ReceiveActor
    {
        private readonly Dictionary<Guid, Book> _books = new Dictionary<Guid, Book>();
        public BookManagerActor()
        {
            Receive<CreateBook>(cmd =>
           {
               var newBook = new Book
               {
                   Id = Guid.NewGuid(),
                   Title = cmd.Title,
                   Author = cmd.Author,
                   Cost = cmd.Cost,
                   InventoryAmount = cmd.InventoryAmount,
               };
               _books.Add(newBook.Id, newBook);

               using (IServiceScope serviceScope = Context.CreateScope())
               {
                   var newdbBook = new Books
                   {
                       Id = Guid.NewGuid(),
                       Title = cmd.Title,
                       Author = cmd.Author,
                       Cost = cmd.Cost,
                       InventoryAmount = cmd.InventoryAmount,
                   };


                   var bookstoreContext = serviceScope.ServiceProvider.GetService<BooksContext>();
                   bookstoreContext.Books.Add(newdbBook);

                   bookstoreContext.SaveChanges();
               }


           });


            Receive<GetBookById>(req =>
           {
               if (_books.TryGetValue(req.Id, out var book))
               {
                   Sender.Tell(book);
               }
               else
               {
                   Sender.Tell(NotFound.Instance);
               }

           });


            Receive<GetBooks>(req =>
            {
                var books = _books.Select(x => x.Value).ToList();
                Sender.Tell(books);
            });
        }




    }
}
