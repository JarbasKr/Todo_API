using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsEmpty(Id, "Por favor, escreva algo nao nulo.")
            );
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}