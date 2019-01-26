namespace DeviceControlApp.Core.Service
{
    public interface IFactory
    {
        T Get<T>();
    }
}