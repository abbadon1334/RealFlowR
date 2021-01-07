namespace FlowR.Library.Node
{
    public class DomNodeText : DomNodeUuid
    {
        private string _text = string.Empty;

        public string GetText()
        {
            return _text;
        }

        public virtual DomNodeText SetText(string text)
        {
            _text = text;

            return this;
        }
    }
}