using System.Collections.Generic;
using System.Threading.Tasks;
using FlowR.Core;
using FlowR.Core.Tags;

namespace FlowR.UI.Forms
{
    public class Control : NodeControl
    {
        private NodeControl _field;
        private Label _label;
        private string _name;

        /// <inheritdoc />
        protected override string TagName { get; } = "div";

        /// <inheritdoc />
        protected override bool FormAutobind { get; set; } = false;

        /// <summary>
        ///     Set label for the control
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public Control SetLabel(string label)
        {
            _label = Add<Label>(new Dictionary<string, string>
            {
                { "for", _name },
                { "class", "form-label" },
            });
            _label.SetText(label);

            return this;
        }

        public Label GetLabel() => _label;

        /// <summary>
        ///     Set Field for the control
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SetControl<T>() where T : NodeControl, new()
        {
            _field = Add<T>(_name);

            return (T)_field;
        }

        /// <inheritdoc />
        public override string GetControlName()
        {
            return _name;
        }
        /// <inheritdoc />
        public override void SetControlName(string name)
        {
            _name = name;
        }

        /// <inheritdoc />
        public override Task<string> CollectValueAsync(string path = "value")
        {
            return _field.CollectValueAsync(path);
        }
    }
}