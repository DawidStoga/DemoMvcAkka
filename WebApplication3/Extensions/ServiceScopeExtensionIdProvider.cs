using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;

namespace ApiDemo.Extensions
{
    public class ServiceScopeExtensionIdProvider : ExtensionIdProvider<ServiceScopeExtension>
    {
        public override ServiceScopeExtension CreateExtension(ExtendedActorSystem system)
        {
            return new ServiceScopeExtension();
        }

        public static ServiceScopeExtensionIdProvider Instance = new ServiceScopeExtensionIdProvider();

        private ServiceScopeExtensionIdProvider()
        {

        }
    }
}
