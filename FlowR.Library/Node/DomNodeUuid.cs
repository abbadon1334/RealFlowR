using System;

namespace FlowR.Library.Node
{
    /// <summary>
    ///     Manage Identifier
    /// </summary>
    public abstract class DomNodeUuid
    {
        private string _uuid = string.Empty;

        /// <summary>
        ///     Get the UUID Of the Node.
        /// </summary>
        /// <returns></returns>
        public string GetUuid()
        {
            if (_uuid != string.Empty) return _uuid;

            SetUuid(Guid.NewGuid().ToString());

            return GetUuid();
        }

        /// <summary>
        ///     Set UUID for the Node.
        /// </summary>
        /// <param name="uuid"></param>
        /// <exception cref="Exception"></exception>
        public virtual void SetUuid(string uuid)
        {
            if (_uuid == string.Empty)
            {
                _uuid = uuid;
                return;
            }

            throw new Exception($"Element Uuid is not empty (actual : '{_uuid}'))");
        }
    }
}