using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Electrobombas.Infraestructure.Cores.Context
{
    public class InfrastructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
