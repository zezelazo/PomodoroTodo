using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PomodoroTodo.Api.Startup))]

namespace PomodoroTodo.Api
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureMobileApp(app);
    }
  }
}