using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid)
            {
                
            // Gera o TodoItem
            var todo = new TodoItem(command.Id,command.Title, command.Date, command.User);

            // Salva no banco
            _repository.Create(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
            }
            
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid) 
            {
            // Recupera o TodoItem (Rehidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o título
            todo.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
            }


            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid)
            {

                // Recupera o TodoItem
                var todo = _repository.GetById(command.Id, command.User);
    
                // Altera o estado
                todo.MarkAsDone();
    
                // Salva no banco
                _repository.Update(todo);
    
                // Retorna o resultado
                return new GenericCommandResult(true, "Tarefa salva", todo);
                
            }


            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid)

            {
                // Recupera o TodoItem
                var todo = _repository.GetById(command.Id, command.User);
    
                // Altera o estado
                todo.MarkAsUndone();
    
                // Salva no banco
                _repository.Update(todo);
    
                // Retorna o resultado
                return new GenericCommandResult(true, "Tarefa salva", todo);
            }
            
            return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

        }
    }
}