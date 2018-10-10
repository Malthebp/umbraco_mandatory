using System;
using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Models;

namespace UmbracoMandatory.ViewModels
{
    public class ForumMessage
    {
        public IMember Member { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PreviousPath { get; set; }
    }
}