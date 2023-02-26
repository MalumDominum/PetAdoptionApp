using Autofac;
using PetAdoptionApp.Core.Interfaces;
using PetAdoptionApp.Core.Services;

namespace PetAdoptionApp.Core;
public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope();

        builder.RegisterType<DeleteContributorService>()
                .As<IDeleteContributorService>().InstancePerLifetimeScope();
    }
}
