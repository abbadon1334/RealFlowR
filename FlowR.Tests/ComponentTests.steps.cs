using TechTalk.SpecFlow;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Component tests")]
    public class ComponentTests : BaseTest
    {
        [Given(@"I add class (.*)")] public void AddClass(string className)
        {
            CurrentComponent.AddCSSClass(className);
        }

        [Given(@"I remove class (.*)")] public void RemoveClass(string className)
        {
            CurrentComponent.RemoveCSSClass(className);
        }
    }
}