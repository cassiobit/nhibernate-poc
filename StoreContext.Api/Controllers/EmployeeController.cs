using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreContext.Api.Dtos.Requests;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Api.Controllers
{
    [ApiController]
    [Route("v1/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(CreateEmployeeRequest request)
        {
            Employee emp = new Employee(request.Name, request.Store);
            await _employeeRepository.SaveAsync(emp);
            return Created("", emp);
        }
    }
}