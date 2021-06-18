using Microsoft.Extensions.DependencyInjection;
using ReactiveUI.Testing;

namespace Sextant.Blazor.Tests
{
    internal sealed class RouteLocatorFixture : IBuilder
    {
        private IServiceCollection _services = new ServiceCollection();

        public static implicit operator RouteLocator(RouteLocatorFixture fixture) => fixture.Build();

        public RouteLocatorFixture WithServices(IServiceCollection services) => this.With(out _services, services);

        private RouteLocator Build() => new RouteLocator(_services.BuildServiceProvider());
    }
}
