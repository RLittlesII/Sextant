// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Sextant.Blazor
{
    /// <summary>
    /// Class for location and state changes.
    /// </summary>
    public class NavigationActionEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationActionEventArgs"/> class.
        /// </summary>
        /// <param name="id">Current viewmodel Id.</param>
        /// <param name="uri">Current Uri.</param>
        /// <param name="sextantNavigationType">Type of navigation: back, forward, uri.</param>
        public NavigationActionEventArgs(string id, string uri, SextantNavigationType sextantNavigationType)
        {
            Id = id;
            Uri = uri;
            NavigationType = sextantNavigationType;
        }

        /// <summary>
        /// Gets or the id.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the Uri.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets or sets a value indicating whether navigation has actually occurred yet.
        /// </summary>
        public SextantNavigationType NavigationType { get; set; }
    }
}
