using System;
using observerpattern.Application;
using observerpattern.Domain;

namespace observerpattern.Infrastructure
{
    public class SqlServerNotificationRepository : INotificationRepository
    {
        public void Save(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
