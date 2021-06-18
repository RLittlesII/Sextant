using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ReactiveUI;
using Sextant.Mocks;

namespace Sextant.Blazor.Tests
{
    internal class NavigationViewComponentMock : NavigationViewMock, IComponent, IViewFor<NavigableViewModelMock>
    {
        public NavigableViewModelMock? ViewModel { get; set; }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (NavigableViewModelMock?)value;
        }

        public void Attach(RenderHandle renderHandle)
        {
        }

        public Task SetParametersAsync(ParameterView parameters) => Task.CompletedTask;
    }
}
