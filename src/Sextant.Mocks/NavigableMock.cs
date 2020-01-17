// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Sextant.Mocks
{
    /// <summary>
    /// A mock of a page view model.
    /// </summary>
    public class NavigableMock : INavigable
    {
        private readonly string _id;
        private readonly ISubject<Unit> _navigatedTo;
        private readonly ISubject<Unit> _navigatingTo;
        private readonly ISubject<Unit> _navigatedFrom;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigableMock"/> class.
        /// </summary>
        /// <param name="id">The id of the page.</param>
        public NavigableMock(string? id = null)
        {
            _id = id ?? nameof(NavigableMock);
            _navigatedTo = new Subject<Unit>();
            _navigatedFrom = new Subject<Unit>();
            _navigatingTo = new Subject<Unit>();
        }

        /// <summary>
        /// Gets the ID of the page.
        /// </summary>
        public virtual string Id => _id;

        /// <inheritdoc />
        public IObservable<Unit> NavigatedTo => _navigatedTo.AsObservable();

        /// <inheritdoc />
        public IObservable<Unit> NavigatedFrom => _navigatedTo.AsObservable();

        /// <inheritdoc />
        public IObservable<Unit> NavigatingTo => _navigatedTo.AsObservable();

        /// <inheritdoc/>
        public IObservable<Unit> WhenNavigatedTo(INavigationParameter parameter) =>
            Observable.Return(Unit.Default).Do(_ => _navigatedTo.OnNext(Unit.Default));

        /// <inheritdoc/>
        public IObservable<Unit> WhenNavigatedFrom(INavigationParameter parameter) =>
            Observable.Return(Unit.Default).Do(_ => _navigatedFrom.OnNext(Unit.Default));

        /// <inheritdoc/>
        public IObservable<Unit> WhenNavigatingTo(INavigationParameter parameter) =>
            Observable.Return(Unit.Default).Do(_ => _navigatingTo.OnNext(Unit.Default));
    }
}
