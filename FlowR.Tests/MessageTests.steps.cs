using FlowR.Core;
using FlowR.Tests.Mock;
using FlowR.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Element And Message Tests")]
    public class MessageTests
    {
        public ApplicationMock App;
        public ClientProxyMock Client;

        public Component<Div> CurrentComponent;
        public ClientMessageSent CurrentMessage;

        [Given(@"A new application starts")] public void AppStart()
        {
            Client = new ClientProxyMock();
            App = new ApplicationMock("test", Client);
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

        [Given(@"I call a method (.*)")] public void CallMethod(string name)
        {
            CurrentComponent.CallClientMethod(name);
        }
        
        [When(@"I get a message")] public void ConsumeMessage()
        {
            CurrentMessage = Client.ConsumeMessage();
        }

        [Then(@"Check attribute (.*) is not null")] public void CheckAttributeNotNull(string name)
        {
            Assert.NotEmpty(CurrentComponent.GetAttributeDictionary()[name]);
        }

        [Then(@"Check attribute (.*) has value (.*)")] public void CheckAttributeNotNull(string name, string value)
        {
            Assert.Equal(value, CurrentComponent.GetAttributeDictionary()[name]);
        }
        
        [Then(@"Check the message method : (.*)")] public void CheckMessageMethod(string method)
        {
            Assert.Equal(method, CurrentMessage.Method);
        }
        
        [Then(@"Check the message argument (.*) as (.*)")] public void CheckMessageMethod(int argNum, string value)
        {
            Assert.Equal(value, CurrentMessage.Arguments[argNum]);
        }
    }
}