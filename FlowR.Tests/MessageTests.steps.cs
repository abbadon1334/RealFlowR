using FlowR.Core;
using FlowR.Core.Components;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Element And Message Tests")]
    public class MessageTests : BaseTest
    {
        private ComponentElement<Div> CurrentComponent;

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

        [Then(@"Check attribute (.*) is not null")] public void CheckAttributeNotNull(string name)
        {
            Assert.NotEmpty(CurrentComponent.GetAttributeDictionary()[name]);
        }

        [Then(@"Check attribute (.*) has value (.*)")] public void CheckAttributeNotNull(string name, string value)
        {
            Assert.Equal(value, CurrentComponent.GetAttributeDictionary()[name]);
        }
    }
}