using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.RssHelper
{
    public class RssLink
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public bool Defaultshow { get; set; }

        public RssLink(string title, string uri, bool defaultshow)
        {
            Title = title;
            Uri = uri;
            Defaultshow = defaultshow;
        }
    }
}
