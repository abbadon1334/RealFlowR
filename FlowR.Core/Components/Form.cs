using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Core.Components
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
        public override string TagName { get; protected set; } = "form";

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();

            // remove default behaviour
            SetAttribute("onsubmit", "return false;");
        }

        /// <summary>
        ///     Shorthand to startListen for submit event from form.
        ///     Attach a callback and Add controls to be collected
        ///     If no control is attached it will take all the already binded controls
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public Form OnSubmit(Action<Dictionary<string, object>> callback, params IComponentControl[] controls)
        {
            // set default 
            var controlsToCollect = _controls;

            if (controls.Length > 0) controlsToCollect = controls.ToList();

            On("submit", (sender, args) =>
            {
                callback(CollectValues(controlsToCollect));
            });

            return this;
        }

        private Dictionary<string, object> CollectValues(List<IComponentControl> controlsToCollect)
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

        /// <summary>
        ///     Usually done internally. But it will bind the control to a Form
        /// </summary>
        /// <param name="componentControl"></param>
        public void BindControl(IComponentControl componentControl)
        {
            _controls.Add(componentControl);
        }

        /// <summary>
        ///     @todo need to lower visibility, probably protected.
        /// </summary>
        /// <returns></returns>
        public List<IComponentControl> GetBindedControls()
        {
            return _controls;
        }
    }
}