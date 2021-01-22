using FlowR.Core;
using FlowR.Core.Components;
using FlowR.Tests.Mock;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    public class BaseTest
    {
        public ApplicationMock App;
        public ClientProxyMock Client;

        public ComponentElement<Div> CurrentComponent;
        public ClientMessageSent CurrentMessage;

        [Given(@"A new application")] public void GivenANewApplication()
        {
            App = new ApplicationMock(
                "testApp",
                Client = new ClientProxyMock()
            );
        }

        [When(@"I get the last message")] public void WhenIGetAMessage()
        {
            CurrentMessage = Client.ConsumeMessage();
        }

        [When(@"I get the message at index (.*)")] public void ConsumeMessageOfIndex(int number)
        {
            for (var x = 0; x < number; x++) WhenIGetAMessage();
        }

        [Then(@"Check the message method : (.*)")] public void CheckMessageMethod(string method)
        {
            Assert.Equal(method, CurrentMessage.Method);
        }
    }
}