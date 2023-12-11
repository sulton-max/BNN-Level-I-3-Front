using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Todos.Services;

public interface ITodoService
{
    ValueTask<IList<TodoItem>> GetAsync(bool asNoTracking = false);

    ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default);

    ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default);
}