using Profit.Core.Entities;
using Profit.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Service.IServices
{
    public interface ITodoService
    {
        Task<PaginatedListDto<Todo>> GetAll(int PageIndex, string search);
        Task AddAll(List<Todo> todos);
        
    }
}
