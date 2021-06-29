// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Sextant.Blazor
{
    /// <summary>
    /// Special resolver for Blazor that stores view, viewmodel, and relative url info.
    /// </summary>
    public class RouteLocator
    {
        private readonly IServiceProvider _provider;

        private Dictionary<Type, IViewModel> _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteLocator"/> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        public RouteLocator(IServiceProvider provider)
        {
            _provider = provider;

            // QUESTION: [rlittlesii: June 12, 2021] Get this by type or use the Id?  Or should we formalize Route and enforce a url segment?
            _routes = provider.GetServices<IViewModel>().ToDictionary(x => x.GetType());
        }

        /// <summary>
        /// Gets the <see cref="IViewFor"/> dictionary.
        /// </summary>
        public static ConcurrentDictionary<Type, Type> ViewToViewModelDictionary { get; } = new ConcurrentDictionary<Type, Type>();

        /// <summary>
        /// Gets the route for the registered type.
        /// </summary>
        /// <param name="viewType">The view type.</param>
        /// <returns>The route.</returns>
        public object GetRoute(Type viewType)
        {
            if (viewType == null)
            {
                throw new ArgumentNullException(nameof(viewType));
            }

            Type serviceType = ViewToViewModelDictionary[viewType];
            return _provider.GetService(serviceType);
        }
    }
}
