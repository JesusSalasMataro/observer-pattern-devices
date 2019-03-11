namespace observerpattern.Domain
{
    public class Event
    {
        public Notification Notification { get; }

        public Event(Notification notification)
        {
            Notification = notification;
        }
    }
}
