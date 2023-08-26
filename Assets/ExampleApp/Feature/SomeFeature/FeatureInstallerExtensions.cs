using VContainer;

namespace ExampleApp.Feature.SomeFeature
{
    public static class FeatureInstallerExtensions
    {
        public static void InstallFeature(this ContainerBuilder containerBuilder) =>
            containerBuilder.Register<FeatureImpl>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}