using BasketWebPanel.BindingModels;
using BasketWebPanel.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketWebPanel.Areas.Dashboard.Controllers
{
    public class QueryController : Controller
    {
        // GET: Dashboard/Query


        public ActionResult Index(int? UserId)
        {
            UserQueries model = new UserQueries();
            var responseAdmin = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Admin/GetUserQueries", User, null, true, false, null, "UserId=" + UserId));
            if (responseAdmin == null || responseAdmin is Error)
                ;
            else
            {
                model = responseAdmin.GetValue("Result").ToObject<UserQueries>();
            }
            model.SetSharedData(User);
            return View(model);
        }
        //public ActionResult Index(int? UserId)
        //{

        //        var responseAdmin = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/GetEntityById", User, null, true, false, null, "EntityType=" + (int)BasketEntityTypes.Admin, "Id=" + AdminId.Value));
        //        if (responseAdmin == null || responseAdmin is Error)
        //            ;
        //        else
        //        {
        //            model.Admin = responseAdmin.GetValue("Result").ToObject<AdminViewModel>();
        //        }



        //    return View(model);
        //}
    }
}