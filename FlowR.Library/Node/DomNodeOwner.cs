namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeOwner' visibile pubblicamente
    public class DomNodeOwner : DomNodeText
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeOwner' visibile pubblicamente
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