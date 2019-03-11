using System.Collections.Generic;

namespace observerpattern.Domain
{
    public abstract class Subject : IDeviceService
    {
        private List<Observer> _services;

        public Subject()
        {
            _services = new List<Observer>();
        }

        public void Attach(Observer service)
        {
            _services.Add(service);
        }

        public abstract void Send(Notification notification);

        protected void NotifyAll(Event e)
        {
            foreach (Observer service in _services)
            {
                service.Save(e.Notification);
            }
        }
    }
}
