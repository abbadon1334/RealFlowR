using System;

namespace FlowR.Library.Node
{
    public class DomNodeText : DomNodeInitialize
    {
        private string _text = string.Empty;

        public string GetText()
        {
            return _text;
        }

        public virtual DomNodeText SetText(string text)
        {
            if (IsInitialized() && ((DomNode) this).GetChildrenCount() > 0)
            {
                throw new Exception("@todo SetText destroy the innerHtml, need to find an alternative way to replace Text in nodes, can be a hidden comment before and after (ex. : <!--TXTStart-->text<!--TXTEnd-->)");
            }
            
            _text = text;

            return this;
        }
    }
}