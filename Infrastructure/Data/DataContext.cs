using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public  DbSet<AddUser> AddUsers {get; set;}
    public  DbSet<Category> Categories {get; set;}
    public  DbSet<Comment> Comments {get; set;}
    public  DbSet<TodoTask> TodoTasks {get; set;}
    public  DbSet<User> Users {get; set;}
}
