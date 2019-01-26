namespace DeviceControlApp.Core.Service
{
    public interface IRegistrar
    {
        IRegistrar Register<T,IT>();
        IRegistrar RegisterSingleton<T>(T t) where T : class;
    }
}