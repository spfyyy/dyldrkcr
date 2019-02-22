using Autofac;
using Shared;
using Shared.ViewModels;

namespace Uwp
{
    public static class Ioc
    {
        public static IContainer Container { get; } = Configure();

        private static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UwpSettings>().As<ISettings>();
            builder.RegisterType<UwpNavigation>().As<INavigation>();
            builder.RegisterType<ApplicationState>().SingleInstance();
            builder.RegisterType<LaunchPageViewModel>();
            builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<QueuePageViewModel>();
            builder.RegisterType<VideoPageViewModel>();
            return builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
