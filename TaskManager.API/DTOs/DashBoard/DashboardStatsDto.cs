namespace TaskManager.DTOs.DashBoard
{
    public class DashboardStatsDto
    {
        public  int  TotalTasks { get; set; }
        public  int  CompletedTasks { get; set; }
        public  int  PendingTasks { get; set; }
        public  int  OverDue { get; set; }
        public  int  HighPriority { get; set; }
    }
}
