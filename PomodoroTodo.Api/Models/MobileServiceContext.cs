using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using PomodoroTodo.Api.DataObjects;

namespace PomodoroTodo.Api.Models
{
  public class MobileServiceContext : DbContext
  {
    private const string connectionStringName = "Name=MS_TableConnectionString";

    public MobileServiceContext() : base(connectionStringName)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Add(
          new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
              "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
    }
  }
}
