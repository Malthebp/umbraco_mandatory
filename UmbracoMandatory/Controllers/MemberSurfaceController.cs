using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoMandatory.Controllers
{
    public class MemberSurfaceController : SurfaceController
    {
        // GET: Member
        [HttpPost]
        public ActionResult HandleUpdateMember(ProfileModel model)
        {
            return RedirectToCurrentUmbracoPage();

            if (!ModelState.IsValid)
            {
                return RedirectToCurrentUmbracoPage();
            }

            var service = Services.MemberService;
            var member = service.GetByEmail(model.Email);

            member.Email = model.Email;
            member.Name = model.Name;

            // Save the updated member
            service.Save(member);

            ViewBag.success = true;
            return RedirectToCurrentUmbracoPage();
        }
    }
}