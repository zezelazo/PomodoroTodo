﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PomodoroTodo.Api.DataObjects;
using PomodoroTodo.Api.Models;

namespace PomodoroTodo.Api.Controllers
{
  public class TodoItemController : TableController<TodoItem>
  {
    protected override void Initialize(HttpControllerContext controllerContext)
    {
      base.Initialize(controllerContext);
      MobileServiceContext context = new MobileServiceContext();
      DomainManager = new EntityDomainManager<TodoItem>(context, Request);
    }

    public IQueryable<TodoItem> GetAllTodoItems()
    {
      return Query();
    }                                                     

    public SingleResult<TodoItem> GetTodoItem(string id)
    {
      return Lookup(id);
    }

    public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
    {
      return UpdateAsync(id, patch);
    }

    public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
    {
      TodoItem current = await InsertAsync(item);
      return CreatedAtRoute("Tables", new { id = current.Id }, current);
    }

    public Task DeleteTodoItem(string id)
    {
      return DeleteAsync(id);
    }
  }
}