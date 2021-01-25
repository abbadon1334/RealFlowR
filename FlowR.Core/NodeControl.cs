using System;
using System.Threading.Tasks;
using FlowR.Core.Tags;

namespace FlowR.Core
{
    /// <summary>
    ///     Node Component Control
    /// </summary>
    public abstract class NodeControl : Node, INodeControl
    {
        private Form _form;

        /// <summary>
        ///     Store Control Type
        /// </summary>
        protected abstract string ControlType { get; }

        /// <inheritdoc />
        public string GetControlName()
        {
            return GetAttribute("name");
        }

        /// <inheritdoc />
        public void SetControlName(string name)
        {
            SetAttribute("name", name);
        }

        /// <inheritdoc />
        public Form GetBindedForm()
        {
            return _form;
        }

        /// <inheritdoc />
        public virtual async Task<string> CollectValueAsync(string path = "value")
        {
            return await GetPropertyAsync(path);
        }

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();

            _form = GetFirstOwnerOfType<Form>();
            _form?.Bind(this);
        }

        /// <inheritdoc />
        public string GetControlType()
        {
            return GetAttribute("type");
        }

        /// <inheritdoc />
        protected override void ValidateNode()
        {
            base.ValidateNode();

            if (string.IsNullOrEmpty(GetControlName())) throw new Exception("Control must have a name");
        }
    }
}