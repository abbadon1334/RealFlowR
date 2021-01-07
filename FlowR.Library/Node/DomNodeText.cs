namespace FlowR.Library.Node
{
    public class DomNodeText : DomNodeUuid
    {
        private string _text = string.Empty;

        public string GetText()
        {
            return _text;
        }

        public void SetText(string text)
        {
            _text = text;
        }
    }
}