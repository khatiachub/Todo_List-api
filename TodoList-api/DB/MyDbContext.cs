using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using TodoList_api.models;

namespace TodoList_api.DB
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        { 
            
        }
        public DbSet<Class> tasks{ get; set; }
        
    }
}
