using DL.SDC.Interfaces;
using DL.SDC.Models;
using DL.SDC.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DL.SDC.Services
{
    public class DLEmployeesService : IDLEmployeeService
    {
        private readonly SdcprojectContext _sdcprojectContext;

        public DLEmployeesService(SdcprojectContext sdcprojectContext)
        {
            _sdcprojectContext = sdcprojectContext;
        }

      
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await Task.FromResult(_sdcprojectContext.Employees.Include(o => o.Manager).Include(o => o.RoleCodeNavigation).Where(e => !e.IsDeleted).ToList());
        }

       
        public async Task<List<Employee>> GetManagersAsync()
        {
            return await Task.FromResult(_sdcprojectContext.Employees.Include(o => o.Manager).Include(o => o.RoleCodeNavigation)
                .Where(e => (e.RoleCode == 664 || e.RoleCode == 332) && !e.IsDeleted)
                .ToList());
        }

        
        public async Task<List<Employee>> GetContractEmployeesAsync()
        {
            return await Task.FromResult(_sdcprojectContext.Employees.Include(o => o.Manager).Include(o => o.RoleCodeNavigation)
                .Where(e => e.RoleCode == 876 && !e.IsDeleted)
                .ToList());
        }

        
        public async Task<int> AddEmployeeAsync(DTO.Models.Employee newEmployee)
        {
            
            if (newEmployee.IdNumber.Length != 9)
            {
                throw new ArgumentException("תעודת הזהות חייבת להכיל 9 ספרות.");
            }

            var managerId = _sdcprojectContext.Employees.FirstOrDefault(e => (e.RoleCode == 664 || e.RoleCode == 322) && e.Name == newEmployee.ManagerName)?.Id;
            _sdcprojectContext.Employees.Add(new Employee
            {
                IdNumber = newEmployee.IdNumber,
                Created = DateTime.Now,
                IsDeleted = false,
                ManagerId = managerId,
                Name = newEmployee.Name,
                RoleCode = newEmployee.RoleCode
            });
            try
            {
                return await _sdcprojectContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                return 0;
            }
        }

       
        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _sdcprojectContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                employee.IsDeleted = true; 
                return await _sdcprojectContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("לא נמצא עובד עם מזהה זה.");
            }
        }

        
        public async Task<int> UpdateEmployeeAsync(DTO.Models.Employee updatedEmployee)
        {
            var employee = await _sdcprojectContext.Employees.FindAsync(updatedEmployee.Id);
            if (employee != null)
            {
                
                if (updatedEmployee.IdNumber != employee.IdNumber)
                {
                    throw new ArgumentException("לא ניתן לשנות את תעודת הזהות.");
                }

                
                employee.Name = updatedEmployee.Name;
                employee.RoleCode = updatedEmployee.RoleCode;
                employee.ManagerId = _sdcprojectContext.Employees.FirstOrDefault(e => (e.RoleCode == 664 || e.RoleCode == 322) && e.Name == updatedEmployee.ManagerName)?.Id;

                return await _sdcprojectContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("לא נמצא עובד עם מזהה זה.");
            }
        }
    }
}

