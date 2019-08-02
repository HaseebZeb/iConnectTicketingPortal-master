using BasketWebPanel.Areas.Dashboard.Models;
using BasketWebPanel.BindingModels;
using BasketWebPanel.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static BasketWebPanel.Utility;

namespace BasketWebPanel.Areas.Dashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Dashboard/Home
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var claimIdentity = ((ClaimsIdentity)User.Identity);
            //var fullName = claimIdentity.Claims.FirstOrDefault(x => x.Type == "FullName");
            //var profilePictureUrl = claimIdentity.Claims.FirstOrDefault(x => x.Type == "ProfilePictureUrl");

            WebDashboardStatsViewModel model = new WebDashboardStatsViewModel();

            model.StoreOptions = Utility.GetStoresOptions(User, "All");
            var tmpStoreOptions = model.StoreOptions;
            model.SetSharedData(User);

            if (model.Role == RoleTypes.SubAdmin)
            {
                model.StoreId = (model as BaseViewModel).StoreId;
                model.HotAreaStats.Store_Id = model.StoreId;
                model.HotAreaStats.Store_IdCat = model.StoreId;
            }
            
            var response = await ApiCall.CallApi("api/Admin/GetAdminDashboardStats", User, null, true, false, null, "AdminId=" + model.Id, "Store_Id=" + model.HotAreaStats.Store_Id);

            if (response is Error || response == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, (response as Error).ErrorMessage);
            }
            else
            {
                model = response.GetValue("Result").ToObject<WebDashboardStatsViewModel>();
                if (model.DeviceUsage.Count < 3)
                {
                    for (int i = 0; i <= (3 - model.DeviceUsage.Count); i++)
                    {
                        model.DeviceUsage.Add(new DeviceStats { Count = 0, Percentage = 0 });
                    }
                }
            }

            model.SetSharedData(User);
            if (model.Role == RoleTypes.SubAdmin)
            {
                model.StoreId = (model as BaseViewModel).StoreId;
                model.HotAreaStats.Store_Id = model.StoreId;
                model.HotAreaStats.Store_IdCat = model.StoreId;
            }
            model.StoreOptions = tmpStoreOptions;
            return View(model);

        }


        public ActionResult ResetPassword()
        {
            ResetPasswordBindingModel model = new ResetPasswordBindingModel();
            model.SetSharedData(User);
            return View(model);
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var response = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Admin/ChangePassword", User, model));

                if (response == null || response is Error)
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, (response as Error).ErrorMessage);
                else
                {
                    model.SetSharedData(User);
                    return RedirectToAction("ResetPassword");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }

        public JsonResult FetchHotProductByStoreId(int storeId) // its a GET, not a POST
        {
            var response = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Admin/FetchHotProductByStoreId", User, null, true, false, null,"StoreId=" + storeId, "EntityType=" + (int)BasketEntityTypes.Product));
            var responseCategories = response.GetValue("Result").ToObject<HotAreaStats>();
            

            return Json(responseCategories.HotProducts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchHotCategoriesByStoreId(int storeId) // its a GET, not a POST
        {
            var response = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Admin/FetchHotProductByStoreId", User, null, true, false, null, "StoreId=" + storeId, "EntityType=" + (int)BasketEntityTypes.Category));
            var responseCategories = response.GetValue("Result").ToObject<HotAreaStats>();


            return Json(responseCategories.HotCategorys, JsonRequestBehavior.AllowGet);
        }

        
        public void OrderNotification()
        {
            try
            {
                Global.sharedDataModel.SetSharedData(User);

                var response = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Admin/GetOrderCount", User, null, true, false, null, "StoreId=" + Global.sharedDataModel.StoreId));
                var orderCountModel = response.GetValue("Result").ToObject<OrderCountViewModel>();
                Response.ContentType = "text/event-stream";
                Response.Write(string.Format("data: {0}\n\n", orderCountModel.Count));
                Response.Flush();
                Response.Close();
            }
            catch (Exception ex)
            {
                Utility.LogError(ex);
            }
        }
    }
}