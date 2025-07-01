using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.API.Home;
using VuexyBase.Application.Application.Query.More.IntroScreens;

namespace VuexyBase.Application.Application.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // If there are service implementations in Application itself
            builder.RegisterAssemblyTypes(typeof(IHomeService).Assembly)
               .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Services"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            // Register MediatR itself
            builder.RegisterType<Mediator>()
                   .As<IMediator>()
                   .InstancePerLifetimeScope();
            // Register MediatR handlers

            builder.RegisterAssemblyTypes(typeof(GetIntroScreensQueryHandler).Assembly)
                   .AsImplementedInterfaces();

        }
    }
}
