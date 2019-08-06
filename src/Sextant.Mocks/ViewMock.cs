using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using ReactiveUI;

namespace Sextant.Mocks
{
    /// <summary>
    /// A mock view for <see cref="IView"/>.
    /// </summary>
    /// <seealso cref="IView" />
    public class ViewMock : IView, IDisposable
    {
        private Subject<IViewModel> _pagePopped;
        private Stack<IViewModel> _stack;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewMock"/> class.
        /// </summary>
        public ViewMock()
        {
            _pagePopped = new Subject<IViewModel>();
            _stack = new Stack<IViewModel>();
        }

        /// <inheritdoc />
        public IScheduler MainThreadScheduler => RxApp.MainThreadScheduler;

        /// <inheritdoc />
        public IObservable<IViewModel> PagePopped => _pagePopped.AsObservable();

        /// <inheritdoc />
        public IObservable<Unit> PopModal() =>
            Observable.Return(Unit.Default);

        /// <inheritdoc />
        public IObservable<Unit> PopPage(bool animate = true) =>
            Observable.Return(Unit.Default).Do(_ => _pagePopped.OnNext(new NavigableMock()));

        /// <inheritdoc />
        public IObservable<Unit> PopToRootPage(bool animate = true) =>
            Observable.Return(Unit.Default);

        /// <inheritdoc />
        public IObservable<Unit> PushModal(IViewModel modalViewModel, string contract, bool withNavigationPage = true) =>
            Observable.Return(Unit.Default);

        /// <inheritdoc />
        public IObservable<Unit> PushPage(IViewModel viewModel, string contract, bool resetStack, bool animate = true) =>
            Observable.Return(Unit.Default).Do(_ => _stack.Push(viewModel));

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  // Violates rule
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
