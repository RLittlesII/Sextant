// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using NSubstitute;
using ReactiveUI.Testing;

namespace Sextant.Blazor.Tests
{
    internal class SextantNavigationManagerFixture : IBuilder
    {
        private IJSRuntime _jsRuntime;

        public SextantNavigationManagerFixture()
        {
            _jsRuntime = Substitute.For<IJSRuntime>();
            _jsRuntime
                .InvokeAsync<string>("SextantFunctions.getLocationHref")
                .Returns(new ValueTask<string>("https://reactiveui.net"));

            _jsRuntime
                .InvokeAsync<string>("SextantFunctions.getBaseUri")
                .Returns(new ValueTask<string>("https://reactiveui.net"));
        }

        public static implicit operator SextantNavigationManager(SextantNavigationManagerFixture fixture) =>
            fixture.Build();

        private SextantNavigationManager Build() => new SextantNavigationManager();
    }
}
