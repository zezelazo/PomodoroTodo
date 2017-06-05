using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroTodo.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ToDoDetail : ContentPage
  {
    public ToDoDetail(TodoItem item = null)
    {
      InitializeComponent();
      if (item != null)
        BindingContext = new ViewModels.ToDoDetailViewModel(item);
      else
        BindingContext = new ViewModels.ToDoDetailViewModel();

    }
  }
}
