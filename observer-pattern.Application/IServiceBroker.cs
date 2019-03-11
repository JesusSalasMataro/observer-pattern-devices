using System;
using observerpattern.Domain;

namespace observerpattern.Application
{
    public interface IServiceBroker
    {
        Action<Notification> OnNotificationSucceeded { get; set; }
        Action<Notification> OnNotificationFailed { get; set; }
        void Queue(Notification notification);
    }
}