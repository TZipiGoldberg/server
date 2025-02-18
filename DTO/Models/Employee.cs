using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class Employee
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public int RoleCode { get; set; }

    public string? RoleName { get; set; }

    public int? ManagerId { get; set; }

    public string? ManagerName { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? Created { get; set; }


}
