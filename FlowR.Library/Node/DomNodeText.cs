using System;

namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText' visibile pubblicamente
    public class DomNodeText : DomNodeInitialize
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText' visibile pubblicamente
    {
        private string _text = string.Empty;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText.GetText()' visibile pubblicamente
        public string GetText()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText.GetText()' visibile pubblicamente
        {
            return _text;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText.SetText(string)' visibile pubblicamente
        public virtual DomNodeText SetText(string text)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeText.SetText(string)' visibile pubblicamente
        {
            if (IsInitialized() && ((DomNode)this).GetChildrenCount() > 0)
            {
                throw new Exception("@todo SetText destroy the innerHtml, need to find an alternative way to replace Text in nodes, can be a hidden comment before and after (ex. : <!--TXTStart-->text<!--TXTEnd-->)");
            }

            _text = text;

            return this;
        }
    }
}