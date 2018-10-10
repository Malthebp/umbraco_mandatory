using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using UmbracoMandatory.ViewModels;

namespace UmbracoMandatory.Controllers
{
    public class ForumSurfaceController : SurfaceController
    {

        private readonly IContentService _service;
        public ForumSurfaceController()
        {
            _service = Services.ContentService;
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ForumMessage model)
        {
            IContent comment = _service.CreateContent(model.Subject, 1128, "Message");
            comment.SetValue("messageMember", ApplicationContext.Services.MemberService.GetByEmail(Membership.GetUser().Email));
            comment.SetValue("subject", model.Subject);
            comment.SetValue("cmessage", model.Message);

            _service.SaveAndPublishWithStatus(comment);

            return RedirectToCurrentUmbracoPage();
        }
    }
}