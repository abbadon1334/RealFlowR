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
        ///     On Init will search for a parent form to attach the control
        /// </summary>
        protected virtual bool FormAutobind { get; set; } = true;

        /// <inheritdoc />
        public virtual string GetControlName()
        {
            return GetAttribute("name");
        }

        /// <inheritdoc />
        public virtual void SetControlName(string name)
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

            if (!FormAutobind)
            {
                _form = GetFirstOwnerOfType<Form>();
                _form?.Bind(this);
            }
        }

        /// <inheritdoc />
        protected override void ValidateNode()
        {
            base.ValidateNode();

            if (string.IsNullOrEmpty(GetControlName()))
            {
                throw new Exception("Control must have a name");
            }
        }
    }
}