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

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Pomodoro> Pomodoros { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Add(
          new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
              "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
    }
  }
}
