namespace FlowR.Library.Node
{
    public class DomNodeOwner : DomNodeText
    {
        private DomNode _owner;

        /// <summary>
        /// Get Parent Node.
        /// </summary>
        /// <returns></returns>
        public DomNode GetOwner()
        {
            return _owner;
        }

        /// <summary>
        /// Set Parent Node
        /// </summary>
        /// <remarks>Usually this is called internally after initialize</remarks>
        /// <param name="owner"></param>
        public void SetOwner(DomNode owner)
        {
            _owner = owner;
        }
    }
}