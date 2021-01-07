using System;

namespace FlowR.Library.Node
{
    public class DomNodeUuid : DomNodeInitialize
    {
        protected string Uuid = string.Empty;

        public string GetUuid()
        {
            if (Uuid != string.Empty)
            {
                return Uuid;
            }

            SetUuid(Guid.NewGuid().ToString());

            return GetUuid();
        }

        public virtual void SetUuid(string uuid)
        {
            Uuid = uuid;
        }
    }
}