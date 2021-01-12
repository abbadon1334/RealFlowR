namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement' visibile pubblicamente
    public class MessageElement : Message
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName' visibile pubblicamente
        public enum MethodName
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName' visibile pubblicamente
        {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.CreateElement' visibile pubblicamente
            CreateElement,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.CreateElement' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.RemoveElement' visibile pubblicamente
            RemoveElement,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.RemoveElement' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetAttribute' visibile pubblicamente
            SetAttribute,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetAttribute' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.RemoveAttribute' visibile pubblicamente
            RemoveAttribute,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.RemoveAttribute' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.StartListenEvent' visibile pubblicamente
            StartListenEvent,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.StartListenEvent' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.StopListenEvent' visibile pubblicamente
            StopListenEvent,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.StopListenEvent' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetText' visibile pubblicamente
            SetText,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetText' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetProperty' visibile pubblicamente
            SetProperty,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.SetProperty' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.CallMethod' visibile pubblicamente
            CallMethod
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement.MethodName.CallMethod' visibile pubblicamente
        }
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse' visibile pubblicamente
    public class MessageElementWithResponse : MessageWithResponse
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName' visibile pubblicamente
        public enum MethodName
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName' visibile pubblicamente
        {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName.GetProperty' visibile pubblicamente
            GetProperty,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName.GetProperty' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName.CallMethodGetResponse' visibile pubblicamente
            CallMethodGetResponse
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageElementWithResponse.MethodName.CallMethodGetResponse' visibile pubblicamente
        }
    }
}