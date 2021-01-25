using TechTalk.SpecFlow;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Component tests")]
    public class ComponentTests : BaseTest
    {
        [Given(@"I add class (.*)")] public void AddClass(string className)
        {
            CurrentComponent.AddCssClass(className);
        }

        [Given(@"I remove class (.*)")] public void RemoveClass(string className)
        {
            CurrentComponent.RemoveCssClass(className);
        }
    }
}