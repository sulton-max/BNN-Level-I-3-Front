using AutoMapper;
using ToDo.Api.Dtos.Models;
using ToDo.Domain.Entities;

namespace ToDo.Api.Mappers;

public class TodoMapper : Profile
{
    public TodoMapper()
    {
        CreateMap<TodoItem, TodoDto>().ReverseMap();
    }
}