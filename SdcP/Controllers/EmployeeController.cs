using BL.SDC.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SdcP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
    
        [HttpGet]
        [Authorize]
        public async Task<List<DTO.Models.Employee>> Get()
        {
            var x = await _employeeService.GetEmployeesAsync();

            return await _employeeService.GetEmployeesAsync();
        }

        [HttpGet]
        public async Task<List<DTO.Models.Employee>> GetManagers()
        {
            return await _employeeService.GetManagersAsync();
        }

        [HttpGet]
        public async Task<List<DTO.Models.Employee>> GetOSEmployees()
        {
            return await _employeeService.GetContractEmployeesAsync();
        }

        [HttpPost]
        public async Task<int> Post(DTO.Models.Employee employee)
        {
            if (employee == null)
            {
                return 0;
            }
            return await _employeeService.AddEmployeeAsync(employee);
        }

        [HttpPut]
        public async Task<int> Put(DTO.Models.Employee employee)
        {
            if (employee == null)
            {
                return 0;
            }
            return await _employeeService.UpdateEmployeeAsync(employee);
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _employeeService.DeleteEmployeeAsync(id);
        }


    }
}

