using System;
using System.Threading.Tasks;

namespace FlowR.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ComponentControl<T> : Component<T> 
        where T : Component<T>, IComponentControl 
    {
        private string _controlName;

        /// <inheritdoc cref="IComponentControl.GetControlName"/>
        public string GetControlName() => _controlName;
        
        /// <summary>
        ///     Set control name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T SetControlName(string name)
        {
            if (null != _controlName)
            {
                throw new Exception("Control name cannot be changed after set");
            }
            
            _controlName = name;
            return DerivedClass;
        }

        /// <inheritdoc cref="IComponentControl.Collect"/>
        public async virtual Task<string> Collect(string path = "value")
        {
            return await GetProperty(path);
        }
    }
}