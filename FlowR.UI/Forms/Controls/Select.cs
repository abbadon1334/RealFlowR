namespace FlowR.UI.Forms.Controls
{
    public class Select : Core.Tags.Controls.Select, IBootstrapControl
    {
        public override void Init()
        {
            base.Init();
            AddCssClass("form-select");
        }
    }
}