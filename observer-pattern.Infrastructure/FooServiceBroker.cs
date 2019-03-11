using System;
using observerpattern.Domain;

namespace observerpattern.Application
{
    public class FooServiceBroker : IServiceBroker
    {
        public Action<Notification> OnNotificationSucceeded 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public Action<Notification> OnNotificationFailed 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void Queue(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
