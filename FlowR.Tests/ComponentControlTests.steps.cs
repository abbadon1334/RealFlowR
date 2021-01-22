using System;
using System.Linq;
using FlowR.Core;
using FlowR.Core.Components;
using FlowR.Core.Components.Controls;
using TechTalk.SpecFlow;
using Xunit;

namespace FlowR.Tests
{
    [Binding]
    [Scope(Feature = "Controls tests")]
    public class ComponentControlTests : BaseTest
    {
        private Form _componentForm;

        [Given(@"Add a form")] public void GivenAddAForm()
        {
            _componentForm = App.GetComponentRoot().Add<Form>();
        }

        [Given(@"Add control to form with name (.*)")] public void GivenAddAControlInputToForm(string name)
        {
            _componentForm.Add<Input>(name);
        }

        [Then(@"Check if input (.*) has attribute (.*) with value (.*)")] public void ThenCheckIfInputIsBindToForm(string name, string attrName, string attrValue)
        {
            Assert.Equal(
                attrValue,
                (GetComponentByName(name) as Node)?.GetAttributeDictionary()[attrName]
            );
        }

        [Then(@"Check if input (.*) is binded to form")] public void ThenCheckIfInputWithNameIsBindToForm(string name)
        {
            Assert.Equal(
                name,
                GetComponentByName(name).GetControlName()
            );
        }

        private IComponentControl GetComponentByName(string name)
        {
            try
            {
                return _componentForm.GetBindedControls().First(componentControl => componentControl.GetControlName() == name);
            }
            catch (Exception e)
            {
                // silent intentionally
            }

            return null;
        }
    }
}