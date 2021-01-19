namespace FlowR.Core
{
    /// <inheritdoc />
    public abstract class ComponentElement<T> : Component<T>
        where T : Component<T>
    {
    }
}