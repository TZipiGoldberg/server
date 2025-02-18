using DL.SDC.Models.DbModel;

namespace BL.SDC.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<DTO.Models.Employee>> GetEmployeesAsync();
        Task<List<DTO.Models.Employee>> GetManagersAsync();
        Task<List<DTO.Models.Employee>> GetContractEmployeesAsync();
        Task<int> AddEmployeeAsync(DTO.Models.Employee newEmployee);
        Task<int> DeleteEmployeeAsync(int employeeId);
        Task<int> UpdateEmployeeAsync(DTO.Models.Employee updatedEmployee);
    }
}

