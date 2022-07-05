using Profit.Core.Entities;
using Profit.Core.IRepositories;
using Profit.Service.DTOs;
using Profit.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Service.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task AddAll(List<Todo> todos)
        {
            foreach (var tds in todos)
            {
                tds.Id = 0;
            }
           await todoRepository.AddAll(todos);

        }

        public async Task<PaginatedListDto<Todo>> GetAll(int PageIndex, string search)
        {
            IQueryable<Todo> query;
            int PageSize = 10;
            if (search != "")
            {
                query = todoRepository.GetAll(x => x.Id.ToString().Contains(search) || x.UserId.ToString().Contains(search) || x.Title.Contains(search));
            }
            else
            {
                query = todoRepository.GetAll(x => x.Id > 0);
            }
             
            var items = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            var listItem = new PaginatedListDto<Todo>(items, query.Count(), PageSize, PageIndex);
            return listItem;
        }

     
    }
}
