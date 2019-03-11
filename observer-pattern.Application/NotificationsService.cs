using System.Collections.Generic;
using observerpattern.Domain;

namespace observerpattern.Application
{
    public class NotificationsService
    {
        private readonly List<Subject> _deviceServices;
        private readonly INotificationRepository _notificationRepository;

        public NotificationsService(List<Subject> deviceServices, INotificationRepository notificationRepository)
        {
            _deviceServices = deviceServices;
            _notificationRepository = notificationRepository;

            foreach (Subject deviceService in _deviceServices)
            {
                deviceService.Subscribe(notificationRepository);
            }
        }

        public void Process(List<Notification> notifications)
        {
            foreach (Notification notification in notifications)
            {
                foreach (Subject deviceService in _deviceServices)
                {
                    deviceService.Send(notification);
                }
            }
        }
    }
}
