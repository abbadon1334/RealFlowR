using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowR.Core.Tags.Controls
{
    /// <summary>
    ///     Defines an checkbox control.
    /// </summary>
    public class Checkbox : Input
    {
        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes => new()
        {
            { "type", "checkbox" },
        };

        /// <inheritdoc />
        public override async Task<string> CollectValueAsync(string path = "value")
        {
            var value = await base.CollectValueAsync("checked");

            return value == "true"
                    ? "1"
                    : "0"
                ;
        }

        /// <summary>
        ///     Return if is control is checked
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsChecked()
        {
            return await GetPropertyAsync("checked") == "true";
        }

        /// <summary>
        ///     Set checked state
        /// </summary>
        /// <param name="isChecked"></param>
        public void SetChecked(bool isChecked = true)
        {
            SetProperty("checked", "true");
        }
    }
}