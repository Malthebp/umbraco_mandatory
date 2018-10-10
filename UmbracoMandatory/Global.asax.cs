using System;
using System.Web.Optimization;
using Umbraco.Web;
using UmbracoMandatory;

namespace UmbracoMandatory
{ 
    public class MvcApplication : UmbracoApplication
    {
        protected override void OnApplicationStarted(object sender, EventArgs e)
        {
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
