#define EntityFramework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using ApiDemo.Extensions;
using ApiDemo.Messages;
using ApiDemo.Models;

namespace ApiDemo.Akka
{
    #region wrong-solution 
    //public PersonManagerActor(CompanyContext dbContext)
    //Do not inject DbContext in ctrol ! - because of lifescope of actors
    #endregion

    #region not-elegant-solution 

    //using (var companyContext = new companyContext(/*connection string*/))
    //{
    //    /*...*/
    //}
    #endregion


    #region better-solution
    //     inject IServiceScopeFactory in ctor
    //ManagerActor(IServiceScopeFactory serviceScopeFactory)

    //using (var serviceScope = serviceScopeFactory.CreateScope())
    //        {
    //            var dbContext = serviceScope.ServiceProvider.GetService<CompanyContext>();
    //          .....
    //       }
    #endregion

    #region using-akka-extension

    //IExtension - create ActorSystem Extension  - i.e IServiceScope CreateScope()
    //IExtensionId - Creating, Register, retriving extension with Actorsystem
    #endregion


    public class PersonManagerActor: ReceiveActor
    {
        private readonly Dictionary<decimal, Person> _Persons = new Dictionary<decimal, Person>();
        public PersonManagerActor()
        {
            Receive<CreatePersonMsg>(cmd =>
           {
               //Error simulation
               if (cmd.Person.Name.Equals("ErrorName")) { throw new Exception(); }

#if !EntityFramework
               _Persons.Add(cmd.Person.Pesel, cmd.Person);
#else
               using (IServiceScope serviceScope = Context.CreateScope())
               {

                   var dbContext = serviceScope.ServiceProvider.GetService<CompanyContext>();
                   dbContext.Person.Add(cmd.Person);

                   dbContext.SaveChanges();
               }

#endif
           });

            Receive<GetPersonByPeselMsg>(query =>
           {

               Person person = null;

#if !EntityFramework
               if (_Persons.TryGetValue(query.Pesel, out var person))
#else
               using (IServiceScope serviceScope = Context.CreateScope())
               {

                   var dbContext = serviceScope.ServiceProvider.GetService<CompanyContext>();
                   person = dbContext.Person.FirstOrDefault(p => p.Pesel == query.Pesel);
                   dbContext.SaveChanges();
               }
#endif
               if (person != null)
               {
                   Sender.Tell(PersonMsg.Instane(person));
               }
               else
               {
                   Sender.Tell(NotFoundMsg.Instance);
               }

           });


            Receive<GetPersonsMsg>(req =>
            {
#if !EntityFramework

                var persons = _Persons.Select(x => x.Value).ToList();
                Sender.Tell(persons);
#else
                using (IServiceScope serviceScope = Context.CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetService<CompanyContext>();
                    var persons = dbContext.Person.ToList();
                    Sender.Tell(persons);
                }
#endif
            });
        }

    }
}
