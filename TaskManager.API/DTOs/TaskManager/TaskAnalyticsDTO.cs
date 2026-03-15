namespace TaskManager.MultiTenant.DTOs.TaskManager
{
    public class TaskAnalyticsDTO
    {
        public int Completed { get; set; }
        public int Pending { get; set; }
        public int Overdue { get; set; }
        public int HighPriority { get; set; }
    }
}
