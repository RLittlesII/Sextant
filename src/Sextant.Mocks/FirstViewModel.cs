// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Sextant.Mocks
{
    /// <summary>
    /// The first View Model.
    /// </summary>
    /// <seealso cref="NavigableMock" />
    public class FirstViewModel
        : NavigableMock
    {
        /// <inheritdoc />
        public override string Id => nameof(FirstViewModel);
    }
}
