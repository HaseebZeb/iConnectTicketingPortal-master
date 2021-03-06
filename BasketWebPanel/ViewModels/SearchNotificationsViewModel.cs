﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWebPanel.ViewModels
{
    public class SearchNotificationsViewModel : BaseViewModel
    {
        public SearchNotificationsViewModel()
        {
            Notifications = new List<SearchNotificationViewModel>();
        }

        public List<SearchNotificationViewModel> Notifications { get; set; }
    }

    public class SearchNotificationViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int TargetAudienceType { get; set; }

        public string TargetAudience { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class MyNotificationsViewModel : BaseViewModel
    {
        public MyNotificationsViewModel()
        {
            Notifications = new List<MyNotificationBindingModel>();
        }

        public List<MyNotificationBindingModel> Notifications { get; set; }
    }

    public class MyNotificationBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TimeText { get; set; }
    }
}