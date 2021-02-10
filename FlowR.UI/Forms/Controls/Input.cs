namespace FlowR.UI.Forms.Controls
{
    /// <inheritdoc />
    public class Input : Core.Tags.Controls.Input, IBootstrapControl
    {
        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            AddCssClass("form-input");
        }
    }
}