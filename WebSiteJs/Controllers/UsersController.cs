using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteJs.Models;

namespace WebSiteJs.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public string PartialHtmlUsers()
        {
            List<UserItemViewModel> list = new List<UserItemViewModel>
            {
                new UserItemViewModel
                {
                    Id=1,
                    Name="Петро Васильович"
                },
                new UserItemViewModel
                {
                    Id=2,
                    Name="Іван Васильович"
                },
                new UserItemViewModel
                {
                    Id=3,
                    Name="Сергій Васильович"
                },
                new UserItemViewModel
                {
                    Id=4,
                    Name="Ірина Васильович"
                }
            };
            return this.ConvertPartialViewToString(PartialView("~/Views/Users/_PartialUsers.cshtml",list));
        }
        protected string ConvertPartialViewToString(PartialViewResult partialView)
        {
            using (var sw = new StringWriter())
            {
                partialView.View = ViewEngines.Engines
                  .FindPartialView(ControllerContext, partialView.ViewName).View;

                var vc = new ViewContext(
                  ControllerContext, partialView.View, partialView.ViewData, partialView.TempData, sw);
                partialView.View.Render(vc, sw);

                var partialViewString = sw.GetStringBuilder().ToString();

                return partialViewString;
            }
        }
    }
}