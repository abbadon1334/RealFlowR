using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
    public class Root : DomNode
    {
        public Root(string rootId)
        {
            SetUuid(rootId);
        }
    }
}