using FluentValidation;
using Microsoft.Extensions.Options;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;

namespace ToDo.Infrastructure.Validators;

public class TodoValidator : AbstractValidator<TodoItem>
{
    public TodoValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(todo => todo.Title).NotEmpty().MinimumLength(3).MaximumLength(128);
                RuleFor(todo => todo.IsDone).Equal(false);
                RuleFor(todo => todo.IsFavorite).Equal(false);
                RuleFor(todo => todo.DueTime).GreaterThan(DateTimeOffset.Now);
                RuleFor(todo => todo.ReminderTime).GreaterThan(DateTimeOffset.Now);
            }
        );

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(todo => todo.Title).NotEmpty().MinimumLength(3).MaximumLength(128);
                RuleFor(todo => todo.DueTime).GreaterThan(DateTimeOffset.Now);
                RuleFor(todo => todo.ReminderTime).GreaterThan(DateTimeOffset.Now);
            }
        );
    }
}