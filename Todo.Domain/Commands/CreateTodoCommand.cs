using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands{

    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {

        public CreateTodoCommand(Guid id,string title, string user, DateTime date)
        {
            Id = id;
            Title = title;
            User = user;
            Date = date;
        }

        public Guid Id { get; set; }

        public string Title { get; set;}

        public DateTime Date { get; set; }

        public string User { get; set; }
        
        public void Validate()
        {

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsEmpty(Title, "Por favor, digite um título")
                .IsEmpty(User, "Por favor, Digite um nome valido")
            );
        }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}