// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;

namespace Sextant.Blazor
{
    /// <summary>
    /// Represents a route.
    /// </summary>
    public sealed class SextantRoute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SextantRoute"/> class.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="viewType">The view type.</param>
        /// <param name="viewModelType">The view model type.</param>
        public SextantRoute(string uri, Type viewType, Type viewModelType)
        {
            Uri = uri;
            ViewType = viewType;
            ViewModelType = viewModelType;
        }

        /// <summary>
        /// Gets the URI for the view.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the Veiw Type.
        /// </summary>
        public Type ViewType { get; }

        /// <summary>
        /// Gets the view model type.
        /// </summary>
        public Type ViewModelType { get; }
    }
}
