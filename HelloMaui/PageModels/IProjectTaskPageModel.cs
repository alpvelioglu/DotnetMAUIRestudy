using CommunityToolkit.Mvvm.Input;
using HelloMaui.Models;

namespace HelloMaui.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}