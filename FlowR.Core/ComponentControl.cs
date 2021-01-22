using System;
using System.Threading.Tasks;
using FlowR.Core.Components;

namespace FlowR.Core
{
    /// <summary>
    /// </summary>
    public abstract class ComponentControl<T> : Component<T>
        where T : Component<T>, IComponentControl
    {
        private string _controlName;

        private Form _bindedForm;

        /// <inheritdoc cref="IComponentControl.GetControlName" />
        public string GetControlName()
        {
            return _controlName;
        }

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();

            _bindedForm = TryFindFirstOwnerByType<Form>();
            _bindedForm?.BindControl(DerivedClass);
        }

        /// <summary>
        ///     Return the binded form
        /// </summary>
        public Form GetBindedForm()
        {
            // @todo can be null if added without a form
            return _bindedForm;
        }

        /// <summary>
        ///     Set control name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T SetControlName(string name)
        {
            if (null != _controlName) throw new Exception("Control name cannot be changed after set");

            _controlName = name;
            return DerivedClass;
        }
        
        /// <inheritdoc cref="IComponentControl.Collect" />
        public virtual async Task<string> Collect(string path = "value")
        {
            return await GetProperty(path);
        }
    }
}