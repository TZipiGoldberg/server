using BL.SDC.Interfaces;
using DL.SDC.Interfaces;
using DL.SDC.Models;
using DL.SDC.Models.DbModel;
using Moj.Repositories.Reserves.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.SDC.Services
{
    public class EmployeesService: IEmployeeService
    {
        private readonly IDLEmployeeService _dlEmployeeService;

        public EmployeesService(IDLEmployeeService dlEmployeeService)
        {
            _dlEmployeeService = dlEmployeeService;


        }

        public async Task<List<DTO.Models.Employee>> GetEmployeesAsync()
        {
            return (await _dlEmployeeService.GetEmployeesAsync()).MapList<DTO.Models.Employee>().ToList();
        }

        public async Task<List<DTO.Models.Employee>> GetManagersAsync()
        {
            return (await _dlEmployeeService.GetManagersAsync()).MapList<DTO.Models.Employee>().ToList();
        }

        public async Task<List<DTO.Models.Employee>> GetContractEmployeesAsync()
        {
            return (await _dlEmployeeService.GetContractEmployeesAsync()).MapList<DTO.Models.Employee>().ToList();
        }

        public async Task<int> AddEmployeeAsync(DTO.Models.Employee newEmployee)
        {
            return await _dlEmployeeService.AddEmployeeAsync(newEmployee);
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            return await _dlEmployeeService.DeleteEmployeeAsync(employeeId);
        }

        public async Task<int> UpdateEmployeeAsync(DTO.Models.Employee updatedEmployee)
        {
            return await _dlEmployeeService.UpdateEmployeeAsync(updatedEmployee);
        }
    }
}

