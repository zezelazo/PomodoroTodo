using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PomodoroTodo.Api.DataObjects;
using PomodoroTodo.Api.Models;

namespace PomodoroTodo.Api.Controllers {
  public class PomodoroController : TableController<Pomodoro>
  {
    protected override void Initialize(HttpControllerContext controllerContext)
    {
      base.Initialize(controllerContext);
      MobileServiceContext context = new MobileServiceContext();
      DomainManager = new EntityDomainManager<Pomodoro>(context, Request);
    }

    public IQueryable<Pomodoro> GetAllPomodoros()
    {
      return Query();
    }

    public SingleResult<Pomodoro> GetPomodoro(string id)
    {
      return Lookup(id);
    }

    public Task<Pomodoro> PatchPomodoro(string id, Delta<Pomodoro> patch)
    {
      return UpdateAsync(id, patch);
    }

    public async Task<IHttpActionResult> PostPomodoro(Pomodoro item)
    {
      Pomodoro current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
    }

    public Task DeletePomodoro(string id)
    {
      return DeleteAsync(id);
    }
  }
}