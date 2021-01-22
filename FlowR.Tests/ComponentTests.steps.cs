using TechTalk.SpecFlow;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Component tests")]
    public class ComponentTests : BaseTest
    {
        [Then(@"I Add class (.*)")] public void AddClass(string className)
        {
            CurrentComponent.AddCSSClass(className);
        }

        [Then(@"I Remove class (.*)")] public void RemoveClass(string className)
        {
            CurrentComponent.RemoveCSSClass(className);
        }
    }
}