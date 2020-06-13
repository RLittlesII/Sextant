// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Sextant.Blazor
{
    /// <summary>
    /// Represents a route configuration.
    /// </summary>
    public class RouteConfiguration : IRouteConfiguration
    {
        private readonly IServiceCollection _serviceCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteConfiguration"/> class.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public RouteConfiguration(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        /// <inheritdoc/>
        public IRouteConfiguration RegisterRoute<TView, TViewModel>(string uri)
            where TView : class, IComponent, IViewFor<TViewModel>, new()
            where TViewModel : class, IViewModel
        {
            // var blazorResolver = Locator.Current.GetService<RouteViewViewModelLocator>();
            // blazorResolver.Register<TView, TViewModel>(route, contract);
            //
            // var urlVmGenerator = Locator.Current.GetService<UrlParameterViewModelGenerator>();
            // urlVmGenerator.Register<TViewModel>(generator);

            // Register the IViewFor

            // TODO: [rlittlesii: June 13, 2020] register route by the key.
            _serviceCollection.AddTransient<IViewFor<TViewModel>, TView>();

            // Register the ViewModel
            _serviceCollection.AddTransient<TViewModel>();
            return this;
        }
    }
}
