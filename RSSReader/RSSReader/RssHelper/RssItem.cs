using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSReader.RssHelper
{
    public class RssItem
    {
        private string title;
        private string link;
        private string description;

        public string Title {
            get { return title; }
        }

        public string Link
        {
            get { return link; }
        }

        public string Description
        {
            get { return description; }
        }

        public RssItem(XmlNode itemNode)
        {
            this.title = itemNode.SelectSingleNode("title").InnerText;
            this.link = itemNode.SelectSingleNode("link").InnerText;
            this.description = itemNode.SelectSingleNode("description").InnerText;
        }
    }
}
