using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Electrobombas.Application.Cores.Contexts
{
    public class ApplicationAutofacModule : Autofac.Module
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
