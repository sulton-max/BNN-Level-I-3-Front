using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Dtos.Models;
using ToDo.Application.Todos.Services;
using ToDo.Domain.Entities;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController(ITodoService todoService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await todoService.GetAsync();
        return result.Any() ? Ok(mapper.Map<IEnumerable<TodoDto>>(result)) : NoContent();
    }

    [HttpGet("{todoId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid todoId)
    {
        var result = await todoService.GetByIdAsync(todoId);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] TodoDto todo)
    {
        var result = await todoService.CreateAsync(mapper.Map<TodoItem>(todo));
        return CreatedAtAction(
            nameof(GetById),
            new
            {
                todoId = result.Id
            },
            result
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] TodoDto todo)
    {
        var result = await todoService.UpdateAsync(mapper.Map<TodoItem>(todo));
        return Ok(result);
    }

    [HttpDelete("{todoId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid todoId)
    {
        await todoService.DeleteByIdAsync(todoId);
        return Ok();
    }
}