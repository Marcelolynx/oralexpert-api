using Eleven.OralExpert.Core.Notifications;

namespace Eleven.OralExpert.Core.Generic;

public class ServiceResult<T>
{
    public T Data { get; }
    public bool IsValid => Notifications.Count == 0;
    public List<Notification> Notifications { get; }

    public ServiceResult(T data)
    {
        Data = data;
        Notifications = new List<Notification>();
    }

    public void AddNotification(string property, string message)
    {
        Notifications.Add(new Notification(property, message));
    }

    public void AddNotifications(IEnumerable<Notification> notifications)
    {
        Notifications.AddRange(notifications);
    }
}