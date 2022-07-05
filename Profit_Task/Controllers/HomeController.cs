using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Profit.Core.Entities;
using Profit.Service.IServices;
using Profit_Task.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Profit_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly ITodoService todoService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ITodoService todoService)
        {
            _logger = logger;
            this.configuration = configuration;
            this.todoService = todoService;
        }

        public async Task dataseed()
        {
            List<Todo> todos = new List<Todo>();
                 
            using (var httpClient = new HttpClient())
            {                     
                using var response = await httpClient.GetAsync(configuration.GetSection("Apis")["Todo"]);

                string apiResponse = await response.Content.ReadAsStringAsync();
                todos = JsonConvert.DeserializeObject<List<Todo>>(apiResponse);
               await todoService.AddAll(todos);
            }

           
        }

        public async Task<IActionResult> Index(int page =1, string search="")
        {
            ViewBag.Search = search;
            var ListTodo = await todoService.GetAll(page, search);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = ListTodo.TotalPage;
            List<Todo> todos = ListTodo.Items;
            return View(todos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string search)
        {
           // List<Todo> todos = await todoService.GetSearch(search);
            return LocalRedirect("~/Home/index/?page=1&search=" + search);
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
