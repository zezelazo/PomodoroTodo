using PomodoroTodo.Helpers;
using PomodoroTodo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PomodoroTodo
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      
        ServiceLocator.Instance.Add<IService, MockService>();
      
      MainPage = new NavigationPage(new Pages.ToDosPage())
      {
        BarBackgroundColor = (Color)Current.Resources["primaryBlue"],
        BarTextColor = Color.White
      };
    }    
  }
}
