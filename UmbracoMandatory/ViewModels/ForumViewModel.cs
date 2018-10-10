using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace UmbracoMandatory.ViewModels
{
    public class ForumViewModel : RenderModel
    {
        public ForumViewModel(IPublishedContent content) : base(content)
        {
        }

        public List<ForumMessage> Messages { get; set; } = new List<ForumMessage>();
    }
}