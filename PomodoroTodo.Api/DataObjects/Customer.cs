using System;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server;

namespace PomodoroTodo.Api.DataObjects {
  public class Customer : EntityData {       
    public string Name { get; set; }     
    public Double Rate { get; set; }
    public int ShortRest { get; set; }
    public int LongRest { get; set; }
    public int PomodoroDuration { get; set; }
    public ERateType RateType { get; set; }
    public ICollection<Project> Projects { get; set; }
  }
}