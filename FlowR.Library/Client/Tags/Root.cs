using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
    public class Root : DomNode
    {
        protected override string TagName { get => "div"; }

        public Root(string rootId)
        {
            SetUuid(rootId);
        }
    }
}