using System;

namespace FlowR.Library.Node
{
    public class DomNodeUuid
    {
        private string _uuid = string.Empty;

        public string GetUuid()
        {
            if (_uuid != string.Empty) return _uuid;

            SetUuid(Guid.NewGuid().ToString());

            return GetUuid();
        }

        public virtual void SetUuid(string uuid)
        {
            _uuid = uuid;
        }
    }
}