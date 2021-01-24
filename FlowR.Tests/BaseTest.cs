using FlowR.Core;
using FlowR.Core.Tags;
using FlowR.Tests.Mock;
using Microsoft.Extensions.Logging.Abstractions;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    public class BaseTest
    {
        public ApplicationMock App;
        public ClientProxyMock Client;

        public Div CurrentComponent;
        public ClientMessageSent CurrentMessage;

        [Given(@"A new application")] public void GivenANewApplication()
        {
            App = new ApplicationMock(
                "testApp",
                Client = new ClientProxyMock(),
                NullLogger<Application>.Instance
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
            CurrentComponent.GetOwner().Remove(CurrentComponent);
        }

        [Then(@"Check no null attribute (.*)")] public void CheckAttributeNotNull(string name)
        {
            Assert.NotEmpty(CurrentComponent.GetAttribute(name));
        }

        [Then(@"Check attribute (.*) has value (.*)")] public void CheckAttribute(string name, string value)
        {
            Assert.Equal(value, CurrentComponent.GetAttribute(name));
        }

        [When(@"I get the last message")] public void WhenIGetAMessage()
        {
            CurrentMessage = Client.ConsumeMessage();
        }

        [When(@"I get the message at index (.*)")] public void ConsumeMessageOfIndex(int number)
        {
            for (var x = 0; x < number; x++) WhenIGetAMessage();
        }

        [Given(@"I call a method (.*)")] public void CallMethod(string name)
        {
            CurrentComponent.CallClientMethod(name);
        }

        [Then(@"Check the message method : (.*)")] public void CheckMessageMethod(string method)
        {
            Assert.Equal(method, CurrentMessage.Method);
        }

        [Then(@"Check the message argument (.*) as (.*)")] public void CheckMessageArgument(int argNum, string value)
        {
            Assert.Equal(value, CurrentMessage.Arguments[argNum]);
        }
    }
}