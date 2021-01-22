namespace FlowR.Core.Components.Controls
{
    /// <summary>
    ///     HTML Tag Input
    /// </summary>
    public class Input : ComponentControl<Input>, IComponentControl
    {


        /// <summary>
        ///     Constructor.
        /// </summary>
        public Input()
        {
            SetAttribute("type", InputType);
        }
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "input";

        /// <summary>
        ///     The html input type
        /// </summary>
        protected string InputType { get; set; } = "text";
    }
}