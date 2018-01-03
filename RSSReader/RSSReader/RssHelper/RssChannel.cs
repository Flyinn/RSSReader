using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RSSReader.RssHelper
{
    public class RssChannel
    {
        private List<RssItem> items;
        private List<string> itemTitles;
        private string title;
        private string link;
        private string description;

        public string Title {
            get {return title;}
        }

        public string Title
        {
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

        public IList<RssItem> Description
        {
            get { return this.items.AsReadOnly(); }
        }


        public IList<string> Description
        {
            get { return this.itemTitles.AsReadOnly(); }
        }

        public RssChannel(XmlNode node)
        {
            this.title = node.SelectSingleNode("title").InnerText;
            this.link = node.SelectSingleNode("title").InnerText;
            this.description = node.SelectSingleNode("title").InnerText;
            items = new List<RssItem>();
            itemTitles = new List<string>();

            XmlNodeList itemNodes = node.SelectNodes("item");
            foreach (XmlNode itemNode in itemNodes)
            {
                RssItem item = new RssItem(itemNode);
                items.Add(item);
                itemTitles.Add(item.Title);
            }
        }
    }
}
