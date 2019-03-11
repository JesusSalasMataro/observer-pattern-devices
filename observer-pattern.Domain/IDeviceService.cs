namespace observerpattern.Domain
{
    public interface IDeviceService
    {
        void Send(Notification notification);
    }
}