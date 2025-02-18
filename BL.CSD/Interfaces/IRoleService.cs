using DL.SDC.Models.DbModel;

namespace BL.SDC.Interfaces
{
    public interface IRoleService
    {
  
        Task<List<DTO.Models.EmployeeRole>> GetRolesAsync();

    }
}

