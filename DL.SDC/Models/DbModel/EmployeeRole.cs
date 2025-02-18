using System;
using System.Collections.Generic;

namespace DL.SDC.Models.DbModel
{
    public partial class EmployeeRole
    {
        public int Code { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}




