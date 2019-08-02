using BasketWebPanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketWebPanel.Areas.Dashboard.Models
{
    public class WebDashboardStatsViewModel : BaseViewModel
    {
        public WebDashboardStatsViewModel()
        {
            HotAreaStats = new HotAreaStats();
            StoreOptions = new SelectList(new List<SelectListItem>());
        }
        public int TotalProducts { get; set; }
        public int TotalStores { get; set; }
        public int TotalUsers { get; set; }
        public int TodayOrders { get; set; }
        public double MonthlyEarning { get; set; }
        public List<DeviceStats> DeviceUsage { get; set; }
        public SelectList StoreOptions { get; set; }

        public HotAreaStats HotAreaStats { get; set; }
    }

    public class DeviceStats
    {
        public int Count { get; set; }
        public int Percentage { get; set; }
    }

    public class HotAreaStats
    {
        public int Store_Id { get; set; }
        public int Store_IdCat { get; set; }
        public List<HotProduct> HotProducts { get; set; }
        public List<HotCategory> HotCategorys { get; set; }
    }

    public class HotProduct
    {
        public string Name { get; set; }
        public int OrderCount { get; set; }
    }
    public class HotCategory
    {
        public string Name { get; set; }
        public int OrderCount { get; set; }
    }
}