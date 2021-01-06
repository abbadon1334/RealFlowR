using System;

namespace FlowR.Library.Node
{
    public class DomNodeUuid : DomNodeInitialize
    {
        private Guid _uuid;
        protected string Uuid = "";

        public virtual string GetUuid()
        {
            return Uuid == string.Empty ? _uuid.ToString() : Uuid;
        }

        public void SetUuid(string uuid)
        {
            Uuid = uuid;
        }
    }
}