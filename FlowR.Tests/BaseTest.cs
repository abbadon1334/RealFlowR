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

        [Given(@"I add a div component")] public void AddDiv()
        {
            CurrentComponent = App.GetComponentRoot().Add<Div>();
        }
        
        [Given(@"I SetAttribute (.*) with (.*)")] public void LastElementSetAttribute(string name, string value)
        {
            CurrentComponent.SetAttribute(name, value);
        }

        [Given(@"I remove Attribute with name (.*)")] public void LastElementRemoveAttribute(string name)
        {
            CurrentComponent.RemoveAttribute(name);
        }

        [Given(@"I remove the element")] public void LastElementRemove()
        {
            CurrentComponent.Owner.Remove(CurrentComponent);
        }

        [Then(@"Check no null attribute (.*)")] public void CheckAttributeNotNull(string name)
        {
            Assert.NotEmpty(CurrentComponent.GetAttributeDictionary()[name]);
        }

        [Then(@"Check attribute (.*) has value (.*)")] public void CheckAttribute(string name, string value)
        {
            Assert.Equal(value, CurrentComponent.GetAttributeDictionary()[name]);
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