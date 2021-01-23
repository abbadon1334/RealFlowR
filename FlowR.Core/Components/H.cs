namespace FlowR.Core.Components
{
    /// <summary>
    ///     H tag
    /// </summary>
    public class H : ComponentElement<H>
    {
        /// <inheritdoc />
        public override string TagName { get; protected set; } = "H1";

        /// <summary>
        ///     SetSize of the H element from 1 to 5, default 1.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public H SetSize(int size)
        {
            TagName = "h" + size;

            return this;
        }
    }
}