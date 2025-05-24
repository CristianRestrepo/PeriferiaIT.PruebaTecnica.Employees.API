using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Commands;
using PeriferiaIT.PruebaTecnica.Employees.Application.Employees.Querys;
using PeriferiaIT.PruebaTecnica.Employees.Domain.Dto;

namespace PeriferiaIT.PruebaTecnica.Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IMediator mediator) : ControllerBase
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }

      
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await mediator.Send(new GetEmployeeQuery() { Id = id});

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
       
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmployee(int id, UpdateEmployeeCommand command)
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
                if (!EmployeeExists(id))
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

      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(CreateEmployeeCommand command)
        {
            
            EmployeeDto newEmployee = await mediator.Send(command);
            return CreatedAtAction("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand() { Id = id});
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        private bool EmployeeExists(int id)
        {
            var employees = mediator.Send(new GetAllEmployeesQuery()).GetAwaiter().GetResult();
            return employees.Any(e => e.Id == id);
        }
    }
}
