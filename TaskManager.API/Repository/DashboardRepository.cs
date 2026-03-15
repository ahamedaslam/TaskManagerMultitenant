using Microsoft.EntityFrameworkCore;
using TaskManager.DBContext;
using TaskManager.DTOs.DashBoard;
using TaskManager.Interface;
using TaskManager.Models;
using TaskManager.MultiTenant.DTOs.TaskManager;

namespace TaskManager.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly AuthDBContext _dbContext;


        public DashboardRepository(AuthDBContext authDBContext)
        {
            _dbContext = authDBContext;
        }
        public async Task<DashboardStatsDto> GetDashboardStatsAsync(string tenantId)
        {
            var totalTasks = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId);
            var completedTasks = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && t.IsCompleted);
            var pendingTasks = totalTasks - completedTasks;
            var overdueTasks = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && !t.IsCompleted && t.DueTime != null && t.DueTime < DateTime.UtcNow);
            var highPriority = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && t.Priority == TaskPriority.High);

            return new DashboardStatsDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                PendingTasks = pendingTasks,
                OverDue = overdueTasks,
                HighPriority = highPriority


            };
        }

   

        //public async Task<TaskAnalyticsDTO> GetTaskAnalytics(string tenantId)
        //{
        //    var today = DateTime.UtcNow;

        //    var completed = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && t.IsCompleted);

        //    var pending = await _dbContext.TaskItems.CountAsync(t => t.TenantId == tenantId && !t.IsCompleted);



        //    return new TaskAnalyticsDTO
        //    {
        //        Completed = completed,
        //        Pending = pending,
        //        Overdue = overdue,
        //        HighPriority = highPriority
        //    };
        //}

    }
}
