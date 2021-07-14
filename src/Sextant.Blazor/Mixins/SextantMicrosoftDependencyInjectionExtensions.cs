// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Concurrency;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace Sextant.Blazor
{
    /// <summary>
    /// Microsoft Dependency Injection Extensions for Sextant Blazor registrations.
    /// </summary>
    public static class SextantMicrosoftDependencyInjectionExtensions
    {
        /// <summary>
        /// Adds Sextant dependencies to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The services.</returns>
        public static IServiceCollection AddSextant(this IServiceCollection services)
        {
            RxApp.MainThreadScheduler = WasmScheduler.Default;
            return services.AddSingleton<IView, NavigationRouter>()
                .AddSingleton<IViewStackService, ParameterViewStackService>()
                .AddSingleton<IParameterViewStackService, ParameterViewStackService>()
                .AddSingleton(SextantNavigationManager.Instance)
                .AddSingleton<DefaultViewModelFactory>()
                .AddSingleton<RouteViewViewModelLocator>()
                .AddSingleton<RouteLocator>(provider => new RouteLocator(provider))
                .AddSingleton<UrlParameterViewModelGenerator>();
        }

        /// <summary>
        /// Adds Sextant dependencies to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="routeConfiguration">The route configuration.</param>
        /// <returns>The services.</returns>
        public static IServiceCollection AddSextant(this IServiceCollection services, Action<IRouteConfiguration> routeConfiguration) =>
            services
                .AddSextant()
                .RegisterRoutes(routeConfiguration);

        /// <summary>
        /// Registers a route for sextant.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="routeConfiguration">The route configuration.</param>
        /// <returns>The services.</returns>
        public static IServiceCollection RegisterRoutes(
            this IServiceCollection serviceCollection,
            Action<IRouteConfiguration> routeConfiguration)
        {
            if (routeConfiguration == null)
            {
                throw new ArgumentNullException(nameof(routeConfiguration));
            }

            routeConfiguration(new RouteConfiguration(serviceCollection));
            return serviceCollection;
        }
    }
}
