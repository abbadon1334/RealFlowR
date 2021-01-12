using FlowR.Library.Node;

namespace FlowR.Library.Client.Tags
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Root' visibile pubblicamente
    public class Root : DomNode
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Root' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Root.Root(string)' visibile pubblicamente
        public Root(string rootId)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Root.Root(string)' visibile pubblicamente
        {
            SetUuid(rootId);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Root.TagName' visibile pubblicamente
        protected override string TagName => "div";
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Root.TagName' visibile pubblicamente
    }
}