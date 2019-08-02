using BasketWebPanel.BindingModels;
using BasketWebPanel.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BasketWebPanel.Areas.Dashboard.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        // GET: Dashboard/Settings
        public ActionResult Index()
        {
            Request.RequestContext.HttpContext.Session.Remove("AddBannerImage");
            SettingsViewModel returnModel = new SettingsViewModel();
            var response = AsyncHelpers.RunSync<JObject>(() => ApiCall.CallApi("api/Settings/GetSettings", User, GetRequest: true));

            if (response == null || response is Error)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, (response as Error).ErrorMessage);
            else
                returnModel = response.GetValue("Result").ToObject<SettingsViewModel>();

            returnModel.NearByRadius = Convert.ToInt32(returnModel.NearByRadius / 1609.344);
            returnModel.SetSharedData(User);
            return View("Index", returnModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SettingsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool firstCall = true;

            MultipartFormDataContent content;
            bool FileAttached = (Request.RequestContext.HttpContext.Session["AddBannerImage"] != null);
            ByteArrayContent fileContent;
            JObject response;
            callAgain: content = new MultipartFormDataContent();

            if (FileAttached)
            {


                bool ImageDeletedOnEdit = false;
                var imgDeleteSessionValue = Request.RequestContext.HttpContext.Session["ImageDeletedOnEdit"];
                if (imgDeleteSessionValue != null)
                {
                    ImageDeletedOnEdit = Convert.ToBoolean(imgDeleteSessionValue);
                }
                byte[] fileData = null;

                var ImageFile = (HttpPostedFileWrapper)Request.RequestContext.HttpContext.Session["AddBannerImage"];
                if (FileAttached)
                    using (var binaryReader = new BinaryReader(ImageFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(ImageFile.ContentLength);
                    }




                if (FileAttached)
                {
                    fileContent = new ByteArrayContent(fileData);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = ImageFile.FileName };
                    content.Add(fileContent);
                }

            }

            content.Add(new StringContent(model.Id.ToString()), "Id");
            content.Add(new StringContent(model.Currency), "Currency");
            //content.Add(new StringContent(Convert.ToString(model.DeliveryFee)), "DeliveryFee");
            content.Add(new StringContent(Convert.ToString(model.ServiceFee)), "ServiceFee");

            content.Add(new StringContent(Convert.ToString(model.AboutUs)), "AboutUs");
            content.Add(new StringContent(Convert.ToString(model.Help)), "Help");
            content.Add(new StringContent(Convert.ToString(model.NearByRadius)), "NearByRadius");
            //content.Add(new StringContent(Convert.ToString(model.MinimumOrderPrice)), "MinimumOrderPrice");



            response = await ApiCall.CallApi("api/Settings/SetSettings", User, isMultipart: true, multipartContent: content);
            if (firstCall && Convert.ToString(response).Contains("UnAuthorized"))
            {
                firstCall = false;
                goto callAgain;
            }
            else if (Convert.ToString(response).Contains("UnAuthorized"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "UnAuthorized Error");
            }

            if (response is Error)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, (response as Error).ErrorMessage);
            }
            else
            {
                model.SetSharedData(User);
                Request.RequestContext.HttpContext.Session.Remove("AddBannerImage");
                TempData["SuccessMessage"] = "Settings updated successfully.";
                return Json(new { success = true, responseText = "Success" }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult GeneralSettings()
        {
            Global.sharedDataModel.SetSharedData(User);
            return View(Global.sharedDataModel);
        }

        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase file)
        {
            if (Request.Files.Count == 1)
            {
                Request.RequestContext.HttpContext.Session.Remove("AddBannerImage");
                Request.RequestContext.HttpContext.Session.Add("AddBannerImage", Request.Files[0]);
            }
            return Json("Success");
        }


        [HttpPost]
        public JsonResult DeleteImage()
        {
            Request.RequestContext.HttpContext.Session.Remove("AddBannerImage");
            Request.RequestContext.HttpContext.Session.Add("AddBannerImage", true);
            return Json("Session Cleared");
        }
    }
}