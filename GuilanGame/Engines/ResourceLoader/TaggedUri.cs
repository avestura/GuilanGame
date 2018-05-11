using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuilanGame.Engines.ResourceLoader
{
    public class TaggedUri : Uri
    {
        public TaggedUri(string uriString, string tag = null) : base(uriString)
        {
            Tag = tag;
        }
        public object Tag { get; set; }
    }
}
