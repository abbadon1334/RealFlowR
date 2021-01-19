using System.Threading.Tasks;

namespace FlowR.Core
{
    /// <summary>
    ///     Interface for ComponentControls 
    /// </summary>
    public interface IComponentControl
    {
        /// <summary>
        ///     The name of the control used as key for returning values
        /// </summary>
        public string GetControlName();

        /// <summary>
        ///     Called when Form needs to collect the values from client
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Task<string> Collect(string path = "value");
        // @todo values can be array (ex. multiselect) need to find a way to solve it
    }
}