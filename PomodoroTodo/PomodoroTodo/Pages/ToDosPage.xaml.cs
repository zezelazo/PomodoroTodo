using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroTodo.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ToDosPage : ContentPage
  {
    ToDosViewModel viewModel;
    public ToDosPage()
    {
      InitializeComponent();
      viewModel = new ToDosViewModel();
      BindingContext = viewModel;
    }

    public void OnDelete(object sender, EventArgs e)
    {
      var mi = ((MenuItem)sender);
      DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
    }
  }
}

