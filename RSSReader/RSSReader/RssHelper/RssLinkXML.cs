using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSReader.RssHelper
{
    public class RssLinkXML
    {
        public List<RssLink> GetLinkList()
        {
            List<RssLink> links = new List<RssLink>();
            XmlDocument doc = new XmlDocument();
            doc.Load("RssFavour.xml");
            XmlNode rootNode = doc.SelectSingleNode("links");

            XmlNodeList linkNodes = rootNode.ChildNodes;

            foreach (XmlNode linkNode in linkNodes)
            {
                string title = linkNode.SelectSingleNode("title").InnerText;
                string uri = linkNode.SelectSingleNode("uri").InnerText;
                bool defaultshow = bool.Parse(linkNode.SelectSingleNode("defaultshow").InnerText);

                RssLink linkItem = new RssLink(title, uri, defaultshow);
                links.Add(linkItem);
            }

            return links;
        }
        
    }
}
