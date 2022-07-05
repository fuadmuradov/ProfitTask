using Profit.Core.Entities;
using Profit.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Data.Repositories
{
    public class TodoRepository:Repository<Todo>, ITodoRepository
    {
        private readonly ProfitDbContext context;

        public TodoRepository(ProfitDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task AddAll(List<Todo> todos)
        {
            context.Todos.AddRange(todos);
            await context.SaveChangesAsync();
        }
    }
}
