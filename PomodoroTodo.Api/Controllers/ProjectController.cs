using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PomodoroTodo.Api.DataObjects;
using PomodoroTodo.Api.Models;

namespace PomodoroTodo.Api.Controllers {
  public class ProjectController : TableController<Project>
  {
    protected override void Initialize(HttpControllerContext controllerContext)
    {
      base.Initialize(controllerContext);
      MobileServiceContext context = new MobileServiceContext();
      DomainManager = new EntityDomainManager<Project>(context, Request);
    }

    public IQueryable<Project> GetAllProjects()
    {
      return Query();
    }

    public SingleResult<Project> GetProject(string id)
    {
      return Lookup(id);
    }

    public Task<Project> PatchProject(string id, Delta<Project> patch)
    {
      return UpdateAsync(id, patch);
    }

    public async Task<IHttpActionResult> PostProject(Project item)
    {
      Project current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
    }

    public Task DeleteProject(string id)
    {
      return DeleteAsync(id);
    }
  }
}