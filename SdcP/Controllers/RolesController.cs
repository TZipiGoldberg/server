using BL.SDC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SdcP.Controllers
{

        [Route("api/[controller]/[action]")]
        [ApiController]
    public class RolesController
    {
            private readonly IRoleService _roleService;

            public RolesController(IRoleService roleService)
            {
                _roleService = roleService;
            }

           
            [HttpGet]
            public async Task<List<DTO.Models.EmployeeRole>> Get()
            {
                return await _roleService.GetRolesAsync();
            }


        }
    }

