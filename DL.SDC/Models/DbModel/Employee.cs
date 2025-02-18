using System;
using System.Collections.Generic;

namespace DL.SDC.Models.DbModel;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public int RoleCode { get; set; }

    public int? ManagerId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime Created { get; set; }

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual Employee? Manager { get; set; }

    public virtual EmployeeRole RoleCodeNavigation { get; set; } = null!;
}