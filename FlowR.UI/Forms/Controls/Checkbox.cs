using System.Linq;
using FlowR.Core.Tags;

namespace FlowR.UI.Forms.Controls
{
    /// <summary>
    ///     Bootstrap control
    /// </summary>
    public class Checkbox : Core.Tags.Controls.Checkbox, IBootstrapControl
    {
        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            AddCssClass("form-checkbox-input");
            GetOwner().AddCssClass("form-check");
            GetFirstOwnerOfType<Control>().GetLabel().AddCssClass("form-check-label");
        }
    }
}