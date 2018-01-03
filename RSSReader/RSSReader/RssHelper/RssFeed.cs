using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace RSSReader.RssHelper
{
    public class RssFeed
    {
        /// <summary>
        /// Rss地址
        /// </summary>
        private string uri;
        /// <summary>
        /// RSS实例
        /// </summary>
        private List<RssChannel> channels;

        public string Uri { get { return uri; } }

        public IList<RssChannel> Channels
        { get { return this.channels.AsReadOnly(); } }

        public RssFeed(string rssUri)
        {
            this.uri = rssUri;
            Load(rssUri);
        }

        private void Load(string rssUri)
        {
            WebClient webClient = new WebClient();
            XmlDocument rssXml = new XmlDocument();

            using (Stream rssStream = webClient.OpenRead(rssUri))
            {
                rssXml.Load(rssStream);
            }

            //文档中包含rss才认为是有效的Rss文档
            channels = new List<RssChannel>();
            XmlNode rssNode = rssXml.SelectSingleNode("rss");

            XmlNodeList nodes = rssNode.ChildNodes;

            foreach (XmlNode node in nodes)
            {
                RssChannel channel = new RssChannel(node);
                channels.Add(channel);
            }
        }
    }
}
