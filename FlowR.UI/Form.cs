using System;
using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI
{
    /// <summary>
    ///     Tag Form
    /// </summary>
    /// <example>
    ///     Form.BindControl(fldName);
    ///     Form.BindControls(fldSurname, fldAddress);
    ///     Form.submit(); // for all binded controls, will be called Collect()
    ///     to retrieve the actual value
    ///     @todo add a loading or something during this type of operations
    /// </example>
    public class Form : ComponentElement<Form>
    {

        private readonly List<IComponentControl> _controls = new();
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName => "form";

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();

            // remove default behaviour
            SetAttribute("onsubmit", "return false;");
        }

        public Form OnSubmit(Action<Dictionary<string, object>> callback, params IComponentControl[] controls)
        {
            On("submit", (sender, args) =>
            {
                callback(CollectValues());
            });

            foreach (var control in controls) _controls.Add(control);

            return this;
        }

        private Dictionary<string, object> CollectValues()
        {
            Dictionary<string, object> values = new();
            foreach (var control in _controls)
            {
                var key = control.GetControlName();
                var value = control.Collect();
                values[key] = value;
            }

            return values;
        }
    }
}