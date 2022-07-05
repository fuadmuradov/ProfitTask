using Profit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Core.IRepositories
{
    public interface ITodoRepository:IRepository<Todo>
    {
        Task AddAll(List<Todo> todos);
    }
}
