using System.Threading.Tasks;
using FlowR.Core;

namespace FlowR.UI.Controls
{
    /// <summary>
    ///     HTML Tag Input
    /// </summary>
    public class Input : ComponentControl<Input>, IComponentControl
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName  => "input";

        /// <summary>
        ///     Request from Form on submit
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual async Task<string> Collect(string path = "value")
        {
            return await GetProperty(path);
        }
    }
}