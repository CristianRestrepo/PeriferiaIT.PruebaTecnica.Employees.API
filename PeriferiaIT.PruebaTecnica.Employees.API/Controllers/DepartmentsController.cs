using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Application.Departments.Querys;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;

namespace PeriferiaIT.PruebaTecnica.Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController(
        IMediator mediator) : ControllerBase
    {
       

        /// <summary>
        /// Get all departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments = await mediator.Send(new GetAllDepartmentQuery());
            return Ok(departments);
        }

        /// <summary>
        /// Get all employees by department.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/employees")]
        [ProducesResponseType(typeof(EmployeeDto),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartment(int id)
        {
            var employees = await mediator.Send(new GetEmployeesByDepartmentQuery() { Id = id });
            return Ok(employees);
        }

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await mediator.Send(new GetDepartmentQuery() { Id = id});

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        /// <summary>
        /// Update department
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutDepartment(int id, UpdateDepartmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }           

            try
            {
                await mediator.Send(command);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        /// <summary>
        /// Add department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(CreateDepartmentCommand command)
        {
            DepartmentDto response = await mediator.Send(command);
            return CreatedAtAction("GetDepartment", new { id = response.Id }, response);
        }

        /// <summary>
        /// Delete department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await mediator.Send(new DeleteDepartmentCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        private bool DepartmentExists(int id)
        {
            var departments =  mediator.Send(new GetAllDepartmentQuery()).GetAwaiter().GetResult();
            return departments.Any(e => e.Id == id);
        }
    }
}
