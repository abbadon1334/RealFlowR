using System;

namespace FlowR.Library.Node
{
    /// <summary>
    ///     Manage Owner aka DomNode parent
    /// </summary>
    public abstract class DomNodeOwner : DomNodeText
    {
        private DomNode _owner;

        /// <summary>
        ///     Get Parent Node.
        /// </summary>
        /// <returns></returns>
        public DomNode GetOwner()
        {
            return _owner;
        }

        /// <summary>
        ///     [internal use] Set Parent Node
        /// </summary>
        /// <remarks>Usually this is called internally after initialize</remarks>
        /// <param name="owner"></param>
        public void SetOwner(DomNode owner)
        {
            // @todo find a way to lower visibility
            //AssertOwnerIsNull();
            _owner = owner;
        }

        private void AssertOwnerIsNull()
        {
            if (_owner != null) throw new Exception("Owner already set");
        }
    }
}