using ToDo.Domain.Common.Entities;

namespace ToDo.Domain.Entities;

public class TodoItem : AuditableEntity
{
    public string Title { get; set; } = default!;

    public bool IsDone { get; set; }

    public bool IsFavorite { get; set; }

    public DateTimeOffset DueTime { get; set; }

    public DateTimeOffset ReminderTime { get; set; }
}