using CommunityToolkit.Mvvm.Input;
using Vijai_Rohit_BMICalculator.Models;

namespace Vijai_Rohit_BMICalculator.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}