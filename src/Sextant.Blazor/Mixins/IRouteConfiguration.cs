// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using ReactiveUI;

namespace Sextant.Blazor
{
    /// <summary>
    /// Interface representing a route configuration.
    /// </summary>
    public interface IRouteConfiguration
    {
        /// <summary>
        /// Registers a route.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <typeparam name="TView">The view type.</typeparam>
        /// <typeparam name="TViewModel">The viewmodel type.</typeparam>
        /// <returns>The route configuration.</returns>
        IRouteConfiguration RegisterRoute<TView, TViewModel>(string uri)
            where TView : class, IComponent, IViewFor<TViewModel>, new()
            where TViewModel : class, IViewModel;
    }
}
