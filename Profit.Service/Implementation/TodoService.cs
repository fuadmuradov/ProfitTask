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

        public async Task<PaginatedListDto<Todo>> GetAll(int PageIndex)
        {

            int PageSize = 10;
            var query = todoRepository.GetAll(x=>x.Id>0);
            var items = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            var listItem = new PaginatedListDto<Todo>(items, query.Count(), PageSize, PageIndex);
            return listItem;
        }

        public async Task<List<Todo>> GetSearch(string searchStr)
        {
            var query = todoRepository.GetAll(x=>x.Id.ToString().Contains(searchStr) || x.UserId.ToString().Contains(searchStr) || x.Title.Contains(searchStr));
            return query.ToList();
        }
    }
}
