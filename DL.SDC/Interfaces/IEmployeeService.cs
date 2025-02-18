using DL.SDC.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL.SDC.Interfaces
{
    public interface IDLEmployeeService
    {
       
        Task<List<Employee>> GetEmployeesAsync();

        
        Task<List<Employee>> GetManagersAsync();

        Task<List<Employee>> GetContractEmployeesAsync();

      
        Task<int> AddEmployeeAsync(DTO.Models.Employee newEmployee);

        
        Task<int> DeleteEmployeeAsync(int employeeId);

       
        Task<int> UpdateEmployeeAsync(DTO.Models.Employee updatedEmployee);
    }
}

