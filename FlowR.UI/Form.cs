using FlowR.Core;

namespace FlowR.UI
{
    /// <summary>
    /// Tag Form
    /// </summary>
    /// <example>
    ///
    /// Form.BindControl(fldName);
    /// 
    /// Form.BindControls(fldSurname, fldAddress);
    ///
    /// Form.submit(); // for all binded controls, will be called Collect()
    /// to retrieve the actual value
    /// @todo add a loading or something during this type of operations 
    /// </example>
    public class Form : Node
    {
        /// <inheritdoc cref="Node.TagName" />
        public new readonly string TagName = "form";
    }
}