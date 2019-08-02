using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketWebPanel.ViewModels
{
    public class UserQueriesViewModel 
    {
       public UserQueriesViewModel()
        {
            User = new UserViewModel();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean isDeleted { get; set; }
        public UserViewModel User { get; set; }
    }

    public class UserQueries : BaseViewModel
    {
        public List<UserQueriesViewModel> Queries { get; set; }
    }
}