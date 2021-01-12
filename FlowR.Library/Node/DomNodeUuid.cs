using System;

namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeUuid' visibile pubblicamente
    public class DomNodeUuid
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeUuid' visibile pubblicamente
    {
        private string _uuid = string.Empty;

        /// <summary>
        /// Get the UUID Of the Node.
        /// </summary>
        /// <returns></returns>
        public string GetUuid()
        {
            if (_uuid != string.Empty) return _uuid;

            SetUuid(Guid.NewGuid().ToString());

            return GetUuid();
        }
        /// <summary>
        /// Set UUID for the Node.
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