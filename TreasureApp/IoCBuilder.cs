using Autofac;
using Core.Contracts;
using Core.Services;
using Infrastructure.Contexts;
using TreasureApp;
using TreasureApp.Core.Contracts;

namespace TreasureHunt
{
    public class IoCBuilder
    {

        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GameUI>().As<GameUI>();
            builder.RegisterType<MazeIntegrationService>().As<IMazeIntegration>();
            builder.RegisterType<HandleInputFromUserService>().As<IHandleInput>();
            builder.RegisterType<TakeUserInputFromConsoleService>().As<ITakeUserInput>();
            builder.RegisterType<BuildMazeService>().As<IBuildMaze>();
            builder.RegisterType<RenderMazeService>().As<IRenderMaze>();
            builder.RegisterType<ExecuteUserActionService>().As<IExecuteUserAction>();            
            builder.RegisterType<MazeMemoryContext>().As<ILoadMaze>().SingleInstance();
            builder.RegisterType<PlayerMemoryContext>().As<ILoadPlayer>().SingleInstance();

            return builder.Build();
        }
    }
}
