using Covid.Data;
using Covid.Entities;
using Covid.Interfaces;
using Covid.Services;
using Microsoft.AspNetCore.Mvc;

namespace Covid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult<InsertReturnDto> InsertEmployeeData(EmployeeData employeeData)
        {
            InsertReturnDto insertReturnDto = new InsertReturnDto();

            if (_employeeService.InsertEmployeeData(employeeData))
                insertReturnDto.Status = "Ok";
            else
                insertReturnDto.Status = "Failed";

            return insertReturnDto;
        }
    }
}
