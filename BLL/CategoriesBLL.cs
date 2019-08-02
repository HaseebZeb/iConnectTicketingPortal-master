using BasketWebPanel;
using BasketWebPanel.Areas.Dashboard.Models;
using BasketWebPanel.BindingModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    class CategoriesBLL : Controller
    {
        //public JsonResult FetchCategories(int storeId) // its a GET, not a POST, Get and Post
        //{
        //    var response = AsyncHelpers.RunSync<JObject>(() => ApiCall<AddCategoryViewModel>.CallGetApi("api/GetAllCategoriesByStoreId", "StoreId=" + storeId));
        //    var responseCategories = response.GetValue("Result").ToObject<List<CategoryBindingModel>>();
        //    var tempCats = responseCategories.ToList();

        //    foreach (var cat in responseCategories)
        //    {
        //        cat.Name = cat.GetFormattedBreadCrumb(tempCats);
        //    }

        //    responseCategories.Insert(0, new CategoryBindingModel { Id = 0, Name = "None" });

        //    return Json(responseCategories, JsonRequestBehavior.AllowGet);

        //}
    }
}
