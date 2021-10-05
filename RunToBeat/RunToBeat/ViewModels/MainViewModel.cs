using ReactiveUI;
using RunToBeat.Core.Service;
using RunToBeat.ViewModels;
using System.Reactive.Concurrency;

namespace RunToBeat.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IScheduler mainThreadScheduler = null,
                IScheduler taskPoolScheduler = null,
                IStepsService stepsService = null,
                IScreen hostScreen = null) : base("Main Page", mainThreadScheduler, taskPoolScheduler, hostScreen)
        {
        }
    }
}