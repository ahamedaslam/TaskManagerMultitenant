using TaskManager.DTOs.DashBoard;
using TaskManager.MultiTenant.DTOs.TaskManager;

namespace TaskManager.Interface
{
    public interface IDashboardRepository
    {
        Task<DashboardStatsDto> GetDashboardStatsAsync(string tenantId);

    }
}
