using BasketWebPanel.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketWebPanel.ViewModels
{
    public class EarningStatisticsViewModel : BaseViewModel
    {
        public StatisticsViewModel Statistics { get; set; }
        public SelectList PaymentMethodOptions { get; internal set; }
        public SelectList Categories { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class EarninigsListViewModel : BaseViewModel
    {
        public List<StatisticsViewModel> Statistics { get; set; }
    }
    public class StatisticsViewModel
    {


        public int Id { get; set; }

        public double Total { get; set; }

        public string Name { get; set; }

        public DateTime OrderDateTime { get; set; }

        public int PaymentMethod { get; set; }

        public string PaymentMethodName { get; set; }

        public double GrandTotal { get; set; }

    }
}