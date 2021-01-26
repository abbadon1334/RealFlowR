using System;
using System.Collections.Generic;

namespace FlowR.Core.Tags
{
    /// <summary>
    ///     Defines an HTML form for user input.
    ///     that having interactive input controls
    ///     to submit form information to a server.
    /// </summary>
    public class Form : NodeComponent
    {

        private readonly Dictionary<string, INodeControl> _controls = new();

        /// <inheritdoc />
        protected override string TagName => "form";

        /// <summary>
        ///     [internal call] Bind an INodeControl to this Form.
        /// </summary>
        /// <see cref="NodeControl.ValidateNode" />
        /// <param name="control"></param>
        /// <exception></exception>
        public void Bind(INodeControl control)
        {
            if (_controls.ContainsKey(control.GetControlName())) throw new Exception("You cannot add control with same name twice");

            _controls.Add(control.GetControlName(), control);
        }

        /// <summary>
        ///     Get related controls.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, INodeControl> GetControls()
        {
            return _controls;
        }
    }
}