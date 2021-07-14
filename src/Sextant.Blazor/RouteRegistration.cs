// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Concurrent;
using ReactiveUI;

namespace Sextant.Blazor
{
    /// <summary>
    /// Route registration.
    /// </summary>
    public static class RouteRegistration
    {
        /// <summary>
        /// Gets the <see cref="IViewFor"/> dictionary.
        /// </summary>
        public static ConcurrentDictionary<Type, Type> ViewToViewModelDictionary { get; } =
            new ConcurrentDictionary<Type, Type>();
    }
}
