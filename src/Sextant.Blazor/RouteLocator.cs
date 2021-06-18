// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Sextant.Blazor
{
    /// <summary>
    /// Special resolver for Blazor that stores view, viewmodel, and relative url info.
    /// </summary>
    public class RouteLocator
    {
        /// <summary>
        /// Used to resolve View Type from ViewModel Type string and contract.
        /// </summary>
        private Dictionary<(string vmTypeName, string contract), Type> _viewModelToViewTypeDictionary;

        /// <summary>
        /// Used to resolve ViewModel Type from View Type string.
        /// </summary>
        private Dictionary<string, Type> _viewToViewModelTypeDictionary;

        /// <summary>
        /// Used to resolve ViewModel Type from a url route.
        /// This is Blazor specific as a user can just type in a URL directly (or a bookmark).
        /// </summary>
        private Dictionary<string, Type> _routeToViewModelTypeDictionary;

        /// <summary>
        /// Used to resolve a url route for a ViewModel Type string.
        /// This is Blazor specific as a user can just type in a URL directly (or a bookmark).
        /// </summary>
        private Dictionary<string, string> _viewModelTypeToRouteDictionary;

        private Dictionary<Type, IViewModel> _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteLocator"/> class.
        /// </summary>
        /// <param name="provider">The service provider.</param>
        public RouteLocator(IServiceProvider provider)
        {
            _viewModelToViewTypeDictionary = new Dictionary<(string vmTypeName, string contract), Type>();
            _viewToViewModelTypeDictionary = new Dictionary<string, Type>();

            _routeToViewModelTypeDictionary = new Dictionary<string, Type>();
            _viewModelTypeToRouteDictionary = new Dictionary<string, string>();

            // QUESTION: [rlittlesii: June 12, 2021] Get this by type or use the Id?  Or should we formalize Route and enforce a url segment?
            _routes = provider.GetServices<IViewModel>().ToDictionary(x => x.GetType());
        }

        /// <summary>
        /// Method to get route for viewmodel type.
        /// </summary>
        /// <param name="viewModelType">The viewmodel Type.</param>
        /// <returns>The route.</returns>
        public string ResolveRoute(Type viewModelType)
        {
            if (viewModelType == null)
            {
                throw new ArgumentNullException(nameof(viewModelType));
            }

            if (_viewModelTypeToRouteDictionary.ContainsKey(viewModelType.AssemblyQualifiedName))
            {
                return _viewModelTypeToRouteDictionary[viewModelType.AssemblyQualifiedName];
            }

            return null;
        }
    }
}
