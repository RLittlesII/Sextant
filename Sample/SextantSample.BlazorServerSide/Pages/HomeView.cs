using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace SextantSample.BlazorServerSide.Pages
{
    public partial class HomeView
    {
        public async Task GreenPageCommand()
        {
            ViewModel?
                .PushGenericPage
                .Execute()
                .Catch(Observable.Return(Unit.Default))
                .Subscribe();
        }
        
        public async Task RedPageCommand()
        {
            ViewModel?
                .PushPage
                .Execute()
                .Catch(Observable.Return(Unit.Default))
                .Subscribe();
        }
        
        public async Task ModalCommand()
        {
            ViewModel?
                .OpenModal
                .Execute()
                .Catch(Observable.Return(Unit.Default))
                .Subscribe();
        }
    }
}
