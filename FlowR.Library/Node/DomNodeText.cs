using System;

namespace FlowR.Library.Node
{
    public class DomNodeText : DomNodeUuid
    {
        private string _text = String.Empty;

        public string GetText() => _text;
        public void SetText(string text) => _text = text;
    }
}