﻿// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using System.Text;
using Splat;

[assembly:InternalsVisibleTo("Sextant.Blazor.Tests")]

namespace Sextant.Blazor
{
    /// <summary>
    /// Extensions methods to setup the <see cref="Sextant"/> instance.
    /// </summary>
    public static class SextantExtensions
    {
        /// <summary>
        /// Initializes the specified sextant.
        /// </summary>
        /// <param name="sextant">The sextant.</param>
        public static void InitializeBlazor(this Sextant sextant)
        {
            if (sextant == null)
            {
                throw new ArgumentNullException(nameof(sextant));
            }

            sextant
                .MutableLocator
                .RegisterParameterViewStackService()
                .RegisterNavigationRouter()
                .RegisterNavigationManager()
                .RegisterUrlParameterViewModelGenerator()
                .RegisterRouteViewViewModelLocator()
                .RegisterViewStackService()
                .RegisterParameterViewStackService()
                .RegisterViewModelFactory(() => new DefaultViewModelFactory());
        }
    }
}
