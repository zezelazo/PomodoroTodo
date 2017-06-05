using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.Helpers;
using PomodoroTodo.Models;
using PomodoroTodo.Services;
using Xamarin.Forms;

namespace PomodoroTodo.ViewModels
{
    public class ToDosViewModel : ViewModelBase
    {
        IService azureService;

        public ToDosViewModel()
        {
            Title = "ToDo";
            azureService = ServiceLocator.Instance.Resolve<IService>();

            Refresh();
        }

        ObservableCollection<TodoItem> toDoItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> ToDoItems {
            get { return toDoItems; }
            set {
                toDoItems = value;
                OnPropertyChanged("ToDoItems");
            }
        }

        TodoItem selectedToDoItem;

        public TodoItem SelectedToDoItem {
            get { return selectedToDoItem; }
            set {
                selectedToDoItem = value;
                OnPropertyChanged("SelectedItem");

                if (selectedToDoItem != null)
                {
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(new Pages.ToDoDetail(SelectedToDoItem));
                    SelectedToDoItem = null;
                }
            }
        }

        Command refreshCommand;
        public Command RefreshCommand {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var todos = await azureService.GetToDos();
                ToDoItems.Clear();
                foreach (var todo in todos)
                {
                    ToDoItems.Add(todo);
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        Command addNewItemCommand;
        public Command AddNewItemCommand {
            get { return addNewItemCommand ?? (addNewItemCommand = new Command(async () => await ExecuteAddNewItemCommand())); }
        }

        async Task ExecuteAddNewItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Pages.ToDoDetail());
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void Refresh()
        {
            ExecuteRefreshCommand();
            MessagingCenter.Subscribe<ToDoDetailViewModel>(this, "ItemsChanged", (sender) =>
                                                                                 {
                                                                                     ExecuteRefreshCommand();
                                                                                 });
        }
    }
}
