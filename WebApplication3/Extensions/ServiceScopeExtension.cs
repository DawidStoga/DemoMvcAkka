using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication3.Extensions
{
    public class ServiceScopeExtension : IExtension
    {
        private IServiceScopeFactory _serviceScopeFactory;

        public void Initialize(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IServiceScope CreateScope()
        {
            return _serviceScopeFactory.CreateScope();
        }
    }
}
