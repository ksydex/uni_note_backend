using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using UniNote.Application.Helpers;
using UniNote.Core.Common.Interfaces;
using UniNote.Core.Helpers;
using UniNote.Data;
using UniNote.Data.Common;
using Module = Autofac.Module;

namespace UniNote.Application;

public class DefaultApplicationModule : Module
{
    private readonly bool _isDevelopment;
    private readonly Assembly[] _assemblies;

    public DefaultApplicationModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        _assemblies = AssemblyHelpers.GetAssemblies(callingAssembly).ToArray();
    }

    protected override void Load(ContainerBuilder builder)
    {
        if (_isDevelopment) RegisterDevelopmentOnlyDependencies(builder);
        else RegisterProductionOnlyDependencies(builder);

        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        // registering repos
        builder.RegisterType<EfRepository>().As<IRepository>().InstancePerLifetimeScope();
        builder.RegisterType<AppDbContext>().As<DbContext>().InstancePerLifetimeScope();

        RegisterMediatr(builder);
        RegisterMapper(builder);

        // registering all services that implements IServicePerLifeTimeScope
        builder
            .RegisterAssemblyTypes(_assemblies)
            .AssignableTo<IServicePerLifeTimeScope>()
            .AsSelf()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }

    private void RegisterMediatr(ContainerBuilder builder)
    {
        builder
            .RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        builder.Register<ServiceFactory>(context =>
        {
            var c = context.Resolve<IComponentContext>();
            return t => c.Resolve(t);
        });

        foreach (var mediatrOpenType in new[]
                 {
                     typeof(IRequestHandler<,>),
                     typeof(IRequestExceptionHandler<,,>),
                     typeof(IRequestExceptionAction<,>),
                     typeof(INotificationHandler<>)
                 })
            builder
                .RegisterAssemblyTypes(_assemblies)
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
    }

    private static void RegisterMapper(ContainerBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(opts =>
        {
            opts.AllowNullCollections = true;
            ReflectionHelpers
                .GetTypesInNamespace(Assembly.GetExecutingAssembly(), "UniNote.Application.MappingProfiles")
                .Where(x => Attribute.GetCustomAttribute(x, typeof(CompilerGeneratedAttribute)) == null).ToList()
                .ForEach(x => opts.AddProfile(Activator.CreateInstance(x) as Profile));
        });
        builder.RegisterInstance(mapperConfig.CreateMapper()).SingleInstance();
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // TODO: Add development only services
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // TODO: Add production only services
    }
}