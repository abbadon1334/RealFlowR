namespace FlowR.UI.Forms.Controls
{
    /// <summary>
    ///     Boostrap element.
    /// </summary>
    public class Select : Core.Tags.Controls.Select, IBootstrapControl
    {
        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            AddCssClass("form-select");
        }
    }
}