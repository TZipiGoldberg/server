using DL.SDC.Interfaces;
using DL.SDC.Models;
using DL.SDC.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.SDC.Services
{
    public class DLRolesService:IDLRoleService
    {
        private readonly SdcprojectContext _sdcprojectContext;
        public DLRolesService(SdcprojectContext sdcprojectContext)
        {
            _sdcprojectContext = sdcprojectContext;
        }
        public async Task<List<EmployeeRole>> GetRolesAsync()
        {
            return await Task.FromResult(_sdcprojectContext.EmployeeRoles.ToList());
        }

    }
}
