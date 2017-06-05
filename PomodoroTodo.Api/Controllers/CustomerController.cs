using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PomodoroTodo.Api.DataObjects;
using PomodoroTodo.Api.Models;

namespace PomodoroTodo.Api.Controllers {
  public class CustomerController : TableController<Customer>
  {
    protected override void Initialize(HttpControllerContext controllerContext)
    {
      base.Initialize(controllerContext);
      MobileServiceContext context = new MobileServiceContext();
      DomainManager = new EntityDomainManager<Customer>(context, Request);
    }

    public IQueryable<Customer> GetAllCustomers()
    {
      return Query();
    }

    public SingleResult<Customer> GetCustomer(string id)
    {
      return Lookup(id);
    }

    public Task<Customer> PatchCustomer(string id, Delta<Customer> patch)
    {
      return UpdateAsync(id, patch);
    }

    public async Task<IHttpActionResult> PostCustomer(Customer item)
    {
      Customer current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
    }

    public Task DeleteCustomer(string id)
    {
      return DeleteAsync(id);
    }
  }
}