using observerpattern.Domain;

namespace observerpattern.Application
{
    public class IosService : Subject
    {
        private readonly DeviceConfiguration _configuration;
        private readonly IServiceBroker _serviceBroker;

        public IosService(DeviceConfiguration configuration, IServiceBroker serviceBroker) 
            : base()
        {
            _configuration = configuration;
            _serviceBroker = serviceBroker;
            _serviceBroker.OnNotificationSucceeded = OnNotificationSucceed;
            _serviceBroker.OnNotificationFailed = OnNotificationFailed;
        }

        public override void Send(Notification notification)
        {
            _serviceBroker.Queue(notification);
        }

        public void OnNotificationSucceed(Notification notification)
        {
            NotifyAll(new Event(notification));
        }

        public void OnNotificationFailed(Notification notification)
        {
            NotifyAll(new Event(notification));
        }
    }
}
