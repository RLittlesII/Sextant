using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Sextant.Mocks;
using Xunit;

namespace Sextant.Blazor.Tests
{
    /// <summary>
    /// Tests to verify behaviors of RouteLocator.
    /// </summary>
    public class RouteLocatorTests
    {
        /// <summary>
        /// Tests that resolving a ViewModel produces a type.
        /// </summary>
        [Fact]
        public void Should_Resolve_Type()
        {
            // Given
            var services = new ServiceCollection();
            services.RegisterRoutes(routes =>
                routes
                    .RegisterRoute<NavigationViewComponentMock, NavigableViewModelMock>("test"));
            RouteLocator sut = new RouteLocatorFixture().WithServices(services);

            // When
            var result = sut.ResolveViewType<NavigableViewModelMock>();

            // Then
            result
                .Name
                .Should()
                .Be("hello");
        }

        /// <summary>
        /// Tests that resolving a ViewModel produces a new instance every execution.
        /// </summary>
        [Fact]
        public void Should_Resolve_New_Instance()
        {
            // Given
            var services = new ServiceCollection();
            services.RegisterRoutes(routes =>
                routes
                    .RegisterRoute<NavigationViewComponentMock, NavigableViewModelMock>("test"));
            RouteLocator sut = new RouteLocatorFixture().WithServices(services);

            // When
            var first = sut.ResolveViewType<NavigationViewMock>();
            var second = sut.ResolveViewType<NavigableViewModelMock>();

            // Then
            first
                .Should()
                .NotBe(second);
        }
    }
}
