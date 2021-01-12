namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal' visibile pubblicamente
    public class MessageGlobal : Message
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal.MethodName' visibile pubblicamente
        public enum MethodName
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal.MethodName' visibile pubblicamente
        {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal.MethodName.CallGlobalMethod' visibile pubblicamente
            CallGlobalMethod
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal.MethodName.CallGlobalMethod' visibile pubblicamente
            ,
            SetProperty
        }
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse' visibile pubblicamente
    public class MessageGlobalWithResponse : MessageWithResponse
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse.MethodName' visibile pubblicamente
        public enum MethodName
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse.MethodName' visibile pubblicamente
        {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse.MethodName.CallGlobalMethodGetResponse' visibile pubblicamente
            CallGlobalMethodGetResponse,
            GetGlobalProperty
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobalWithResponse.MethodName.CallGlobalMethodGetResponse' visibile pubblicamente
        }
    }
}