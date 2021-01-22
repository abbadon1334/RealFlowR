namespace FlowR.Core.Components.Controls
{
    /// <summary>
    ///     HTML Tag Input
    /// </summary>
    public class Input : ComponentControl<Input>, IComponentControl
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName => "input";

        protected string InputType { get; set; } = "text";
        
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        public Input()
        {
            this.SetAttribute("type", InputType);
        }
    }
}