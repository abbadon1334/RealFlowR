namespace FlowR.UI.Forms.Controls
{
    public class Checkbox : Core.Tags.Controls.Checkbox, IBootstrapControl
    {
        public override void Init()
        {
            base.Init();
            AddCssClass("form-checkbox-input");
            GetOwner().AddCssClass("form-check");
            GetFirstOwnerOfType<Control>().GetLabel().AddCssClass("form-check-label");
        }
    }
}