using EfCoreBlazorDemo.Data;
using EfCoreBlazorDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreBlazorDemo.Services
{
    public class TaskService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public TaskService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<List<TaskItem>> ListTasksAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();

            return await context.Tasks.ToListAsync();
        }

        public async Task<TaskItem> AddTaskAsync(TaskItem t)
        {
            ArgumentNullException.ThrowIfNull(t);
            using var context = _dbContextFactory.CreateDbContext();

            context.Tasks.Add(t);
            await context.SaveChangesAsync();
            return t;
        }
        public async Task<TaskItem> UpdateTaskAsync(TaskItem taskItem)
        {
            ArgumentNullException.ThrowIfNull(taskItem);

            using var context = _dbContextFactory.CreateDbContext();

            context.Tasks.Update(taskItem);

            await context.SaveChangesAsync();

            return taskItem;
        }
        public async Task DeleteTaskAsync(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();

            // FindAsync retrieves by primary key.
            var taskItem = await context.Tasks.FindAsync(id);

            // Service layer enforces existence rule (fail fast).
            if (taskItem == null)
            {
                throw new KeyNotFoundException($"Product with id {id} was not found.");
            }

            context.Tasks.Remove(taskItem);
            await context.SaveChangesAsync();
        }
    }
}
