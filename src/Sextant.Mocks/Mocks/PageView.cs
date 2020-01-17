// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using ReactiveUI;

namespace Sextant.Mocks
{
    /// <summary>
    /// Represents a mock page.
    /// </summary>
    public class PageView : IViewFor<NavigableMock>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageView"/> class.
        /// </summary>
        public PageView()
        {
            ViewModel = new NavigableMock();
        }

        /// <inheritdoc/>
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (NavigableMock)value;
        }

        /// <inheritdoc/>
        public NavigableMock ViewModel { get; set; }
    }
}
