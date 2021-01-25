using System.Threading.Tasks;
using FlowR.Core.Tags;

namespace FlowR.Core
{
    /// <summary>
    ///     Node Control
    /// </summary>
    public interface INodeControl : INode
    {
        /// <summary>
        ///     Get the name of the control used as key for returning values
        /// </summary>
        /// <returns></returns>
        public string GetControlName();

        /// <summary>
        ///     Set the name of the control used as key for returning values
        /// </summary>
        /// <returns></returns>
        public void SetControlName(string name);

        /// <summary>
        ///     Get control type like input attribute type
        /// </summary>
        /// <returns></returns>
        public string GetControlType();

        /// <summary>
        ///     Return the binded form
        /// </summary>
        public Form GetBindedForm();

        /// <summary>
        ///     Called when needs to collect the actual value from client
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<string> CollectValueAsync(string path = "value");
    }
}