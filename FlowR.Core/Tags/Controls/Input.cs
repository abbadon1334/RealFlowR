namespace FlowR.Core.Tags.Controls
{
    /// <summary>
    ///     Defines an input control.
    /// </summary>
    public class Input : NodeControl
    {

        public Input()
        {
            SetAttribute("type", ControlType);
        }
        /// <inheritdoc />
        protected override string TagName => "input";

        /// <inheritdoc />
        protected override string ControlType => "text";
    }
}