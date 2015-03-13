using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;


namespace APKO.Helpers
{
    public class RssActionResult : ActionResult  
    {
        public RssActionResult(SyndicationFeed feed)
        {
            RssFeed = feed;
        }

        public SyndicationFeed RssFeed { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            var rssFormatter = new Rss20FeedFormatter(RssFeed);

            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }  
        }
    }
}