using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoMandatory.ViewModels;

namespace UmbracoMandatory.Controllers
{
    public class ForumController : RenderMvcController
    {
        // GET
        public ActionResult Index(RenderModel model)
        {
            var viewModel = new ForumViewModel(CurrentPage);
            var messages = CurrentPage
                .Children
                .Where(x => x.Name == "Messages")
                .First().Children
                .Where(x => x.DocumentTypeAlias == "message")
                .ToList()
                .OrderByDescending(x => x.CreateDate);

            foreach(var message in messages)
            {
                viewModel.Messages.Add(new ForumMessage() {
                    Member = message.GetPropertyValue<IMember>("messageMember"),
                    Message = message.GetPropertyValue<string>("cmessage"),
                    Subject = message.GetPropertyValue<string>("subject"),
                    CreatedAt = message.CreateDate
                });
            }

            return View(viewModel);
        }
    }
}