namespace DeviceControlApp.Core.Service
{
    public interface IRegistrar
    {
        void Register<T,IT>();
    }
}