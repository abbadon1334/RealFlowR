using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Node.Collections
{
    public class DomNodeCollectionProperty : DomNodeCollection<string>
    {
        public DomNodeCollectionProperty(DomNode owner) : base(owner)
        {
        }

        public void SetProperty(string name, string value)
        {
            Set(name, value);
        }
    }
}