using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using MediatR;
using Paylocity.Core.Services;

namespace Paylocity.Api
{

    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof (IDiscountService).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IMappingEngine).GetTypeInfo().Assembly).AsImplementedInterfaces();
            

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

//            builder.RegisterInstance(Mapper.Engine).As<IMappingEngine>().ExternallyOwned();
//            builder.RegisterInstance(Mapper.Instance).As<IMapper>().ExternallyOwned();
            builder.Register(c =>
            {
                return Mapper.Instance;
            })
            .As<IMapper>()
            .InstancePerRequest();



            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}