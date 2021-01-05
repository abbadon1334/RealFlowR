using System;

namespace FlowR.Library.Node
{
    public class DomNodeUuid
    {
        private Guid _uuid = new();

        public virtual string GetUuid()
        {
            return _uuid.ToString();
        }
    }
}