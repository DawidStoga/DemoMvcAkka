using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDemo.Extensions
{
    public static class Extensions
    {
     public static void AddServiceScopeFactory(this ActorSystem system, IServiceScopeFactory serviceScopeFactory)
        {
            system.RegisterExtension(ServiceScopeExtensionIdProvider.Instance);
            ServiceScopeExtensionIdProvider.Instance.Get(system).Initialize(serviceScopeFactory);
        }

        public static IServiceScope CreateScope(this IActorContext context)
        {
            return ServiceScopeExtensionIdProvider.Instance.Get(context.System).CreateScope();
        }
    }
}
