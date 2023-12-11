using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Persistence.Repositories.Interfaces;

public interface ITodoRepository
{
    IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default);

    ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default);
}