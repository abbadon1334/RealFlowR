using FlowR.Core.Tags;
using FlowR.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Fluent tests")]
    public class BootstrapFluentTests : BaseTest
    {
        public FluentComponent<Div> FluentDiv;

        [Given(@"I create a full Fluent div")] public void GivenCreateFluentDiv()
        {
            FluentDiv = App.GetComponentRoot()
                    .Add<FluentComponent<Div>>()
                    .SetAttribute("keyA", "valueA")
                    .SetAttribute("keyB", "valueB")
                    .SetAttribute("keyC", "valueC")
                    .SetText("textA")
                    .RemoveAttribute("keyB")
                ;
        }

        [Then(@"Check if fluent div has attribute (.*) with value (.*)")] public void CheckFluentDivAttribute(string key, string value)
        {
            Assert.True(FluentDiv.HasAttribute(key));
            Assert.Equal(
                value,
                FluentDiv.GetAttribute(key)
            );
        }

        [Then(@"Check if fluent div attribute (.*) removed")] public void CheckFluentDivAttribute(string key)
        {
            Assert.False(FluentDiv.HasAttribute(key));
        }
    }
}