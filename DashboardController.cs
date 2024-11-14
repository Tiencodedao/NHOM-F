using Microsoft.AspNetCore.Mvc;

namespace KoiPondManagement.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var dashboardData = new DashboardData
            {
                TotalCustomers = 120,
                CustomerSatisfaction = 4.7,
                CompletedConsultations = 85,
                ActiveProjects = 12,
                AvgCompletionTime = 30,
                MonthlyRevenue = 50000000,
                UnpaidInvoices = 10000000,
                CompletedServiceRequests = 60,
                AvgResponseTime = 3
            };

            return View(dashboardData);
        }
    }

    public class DashboardData
    {
        public int TotalCustomers { get; set; }
        public double CustomerSatisfaction { get; set; }
        public int CompletedConsultations { get; set; }
        public int ActiveProjects { get; set; }
        public int AvgCompletionTime { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal UnpaidInvoices { get; set; }
        public int CompletedServiceRequests { get; set; }
        public int AvgResponseTime { get; set; }
    }
}
