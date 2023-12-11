using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Todos.Services;
using ToDo.Domain.Entities;
using ToDo.Persistence.Repositories.Interfaces;

namespace ToDo.Infrastructure.Todos.Services;

public class TodoService(ITodoRepository todoRepository, IValidator<TodoItem> todoValidator) : ITodoService
{
    public IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false)
    {
        return todoRepository.Get(predicate, asNoTracking);
    }

    public async ValueTask<IList<TodoItem>> GetAsync(bool asNoTracking = false)
    {
        var todos = await todoRepository.Get().ToListAsync();
        return todos
            .Where(todo => !todo.IsDone && todo.DueTime > DateTime.Now).OrderBy(todo => todo.DueTime) // Active todos
            .Concat(todos.Where(todo => todo.IsDone).OrderByDescending(todo => todo.ModifiedTime)) // Completed todos
            .Concat(todos.Where(todo => !todo.IsDone && todo.DueTime <= DateTime.Now).OrderByDescending(todo => todo.DueTime)) // Overdue todos
            .ToList();
    }

    public ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return todoRepository.GetByIdAsync(todoId, asNoTracking, cancellationToken);
    }

    public ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        todoItem.CreatedTime = DateTimeOffset.UtcNow;

        return todoRepository.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    public ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        var validationResult = todoValidator.Validate(todoItem);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return todoRepository.UpdateAsync(todoItem, cancellationToken);
    }

    public ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default)
    {
        return todoRepository.DeleteByIdAsync(todoId, cancellationToken);
    }
}