using BL.SDC.Interfaces;
using DL.SDC.Interfaces;
using DL.SDC.Models.DbModel;
using Moj.Repositories.Reserves.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.SDC.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDLRoleService _dlRoleService;

        public RoleService(IDLRoleService dlRoleService)
        {
            _dlRoleService = dlRoleService;
        }

     
        public async Task<List<DTO.Models.EmployeeRole>> GetRolesAsync()
        {
            return (await _dlRoleService.GetRolesAsync()).MapList<DTO.Models.EmployeeRole>().ToList();
        }

   
    }
}
