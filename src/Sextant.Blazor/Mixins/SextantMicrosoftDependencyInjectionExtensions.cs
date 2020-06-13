// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton<IView, NavigationRouter>();
            services.AddSingleton<IParameterViewStackService, ParameterViewStackService>();
            services.AddSingleton<SextantNavigationManager>();
            services.AddSingleton<DefaultViewModelFactory>();
            services.AddSingleton<RouteViewViewModelLocator>();
            services.AddSingleton<UrlParameterViewModelGenerator>();
            return services;
        }

        /// <summary>
        /// Adds Sextant dependencies to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="routeConfiguration">The route configuration.</param>
        /// <returns>The services.</returns>
        public static IServiceCollection AddSextant(
            this IServiceCollection services,
            Action<IRouteConfiguration> routeConfiguration)
        {
            services.AddSingleton<IView, NavigationRouter>();
            services.AddSingleton<IParameterViewStackService, ParameterViewStackService>();
            services.AddSingleton<SextantNavigationManager>();
            services.AddSingleton<DefaultViewModelFactory>();
            services.AddSingleton<RouteViewViewModelLocator>();
            services.AddSingleton<UrlParameterViewModelGenerator>();
            services.RegisterRoutes(routeConfiguration);
            return services;
        }

        /// <summary>
        /// Registers a route for sextant.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="routeConfiguration">The route configuration.</param>
        public static void RegisterRoutes(
            this IServiceCollection serviceCollection,
            Action<IRouteConfiguration> routeConfiguration)
        {
            if (routeConfiguration == null)
            {
                throw new ArgumentNullException(nameof(routeConfiguration));
            }

            routeConfiguration(new RouteConfiguration(serviceCollection));
        }
    }
}
