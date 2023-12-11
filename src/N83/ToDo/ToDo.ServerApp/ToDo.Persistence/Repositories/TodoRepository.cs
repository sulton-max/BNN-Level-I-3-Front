using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Persistence.DataContexts;
using ToDo.Persistence.Repositories.Interfaces;

namespace ToDo.Persistence.Repositories;

public class TodoRepository : EntityRepositoryBase<TodoItem, AppDbContext>, ITodoRepository
{
    public TodoRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public new IQueryable<TodoItem> Get(Expression<Func<TodoItem, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<TodoItem?> GetByIdAsync(Guid todoId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(todoId, asNoTracking, cancellationToken);
    }

    public new ValueTask<TodoItem> CreateAsync(TodoItem todoItem, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(todoItem, saveChanges, cancellationToken);
    }

    public async ValueTask<bool> UpdateAsync(TodoItem todoItem, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos
            .Where(x => x.Id == todoItem.Id)
            .ExecuteUpdateAsync(propertySetter => propertySetter
                .SetProperty(x => x.Title, todoItem.Title)
                .SetProperty(x => x.IsDone, todoItem.IsDone)
                .SetProperty(x => x.IsFavorite, todoItem.IsFavorite)
                .SetProperty(x => x.DueTime, todoItem.DueTime)
                .SetProperty(x => x.ReminderTime, todoItem.ReminderTime)
                .SetProperty(x => x.ModifiedTime, DateTimeOffset.UtcNow),
            cancellationToken
        );
        return result > 0;
    }

    public async ValueTask<bool> DeleteByIdAsync(Guid todoId, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Todos.Where(x => x.Id == todoId).ExecuteDeleteAsync(cancellationToken);
        return result > 0;
    }
}