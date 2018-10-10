using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using UmbracoMandatory.ViewModels;

namespace UmbracoMandatory.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        private readonly IContentService _service;
        public ContactFormSurfaceController()
        {
            _service = Services.ContentService;
        }

        // GET
        public ActionResult Index()
        {
            return PartialView("_contactForm", new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToCurrentUmbracoPage();
            }

            var message = new MailMessage();
            message.To.Add("malthetest1234@gmail.com");
            message.Subject = model.Subject;
            message.From = new MailAddress(model.Email, model.Name);
            message.Body = model.Message;
            using (SmtpClient client = new SmtpClient())
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("malthetest1234@gmail.com", ".Test1234");
                client.Send(message);
            }
            TempData["success"] = true;
            CreateComment(model);
            return RedirectToCurrentUmbracoPage();
        }

        private void CreateComment(ContactForm model)
        {
            IContent comment = _service.CreateContent(model.Subject, CurrentPage.Id, "Comment");

            comment.SetValue("email", model.Email);
            comment.SetValue("cname", model.Name);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);

            _service.Save(comment);
        }
    }
}