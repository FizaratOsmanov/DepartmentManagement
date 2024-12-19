using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Exceptions.DepartmentExceptions;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.Services.Implementations
{
    public class DepartmentService:IDepartmentService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository,AppDbContext appDbContext)
        {
            _departmentRepository = departmentRepository;
            _appDbContext = appDbContext;
        }

        public async Task<Department> CreateAsync(DepartmentAddDTO addDTO)
        {
            Department department=new Department();
            department.Name=addDTO.Name;
            department.Description=addDTO.Description;
            department.CreatedAt=DateTime.UtcNow.AddHours(4);
            department.IsDeleted=false;
            return await _departmentRepository.CreateAsync(department);
            _appDbContext.SaveChanges();
            
        }



        public void Delete(Department department)
        {
            _appDbContext.Remove(department);
        }

        public async Task<ICollection<Department>> GetAllAsync()
        {
            
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public void Update(Department department)
        {


        }
    }
}
