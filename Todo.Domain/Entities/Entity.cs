using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }


        public bool Equals(Entity other)
        {
            // Adiciona uma verificação para null antes de comparar os IDs.
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }
    }
}