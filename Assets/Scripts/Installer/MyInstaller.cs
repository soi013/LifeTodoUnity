using LifeTodo.Infra;
using LifeTodo.Domain;
using LifeTodo.UseCase;
using UnityEngine;
using Zenject;

namespace LifeTodo.Installer
{
    public class MyInstaller : MonoInstaller<MyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPathSerializeTarget>()
                .To<PathApplicationDataJson>()
                .AsSingle()
                .NonLazy();

            Container.Bind<TodoRepositorySerializer>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<TodoExpireDomainService>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<ITodoRepository>()
                .To<InMemoryTodoRepository>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<TodoAppService>()
                .AsSingle()
                .NonLazy();
        }
    }
}
