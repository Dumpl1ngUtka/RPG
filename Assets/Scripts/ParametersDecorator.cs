public abstract class ParametersDecorator : IParameterProvider
{
    protected readonly IParameterProvider WrappedEntity;
    
    protected ParametersDecorator(IParameterProvider wrappedEntity)
    {
        WrappedEntity = wrappedEntity;
    }

    public PlayerParameters GetParameters()
    {
        return GetParametersInternal();
    }

    protected abstract PlayerParameters GetParametersInternal();
}
