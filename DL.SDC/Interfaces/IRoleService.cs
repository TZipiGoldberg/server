
using DL.SDC.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.SDC.Interfaces
{
    public interface IDLRoleService
    {
        
        Task<List<EmployeeRole>> GetRolesAsync();

    
    }
}