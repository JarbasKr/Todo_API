using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }
        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done == true;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<TodoItem, bool>> GetById(string user, Guid id)
        {
            return x => x.User == user && x.Id == id;
        }

        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x => x.User == user && x.Done == done && x.Date.Date == date.Date;    
        }
        }
}