namespace Eleven.OralExpert.Core.Notifications;

public abstract class Notifiable
{
    private readonly List<DomainNotification> _notifications;

    public IReadOnlyCollection<DomainNotification> Notifications => _notifications;

    protected Notifiable()
    {
        _notifications = new List<DomainNotification>();
    }

    protected void AddNotification(string property, string message)
    {
        _notifications.Add(new DomainNotification(property, message));
    }

    protected void AddNotification(DomainNotification notification)
    {
        _notifications.Add(notification);
    }

    protected void AddNotifications(IEnumerable<DomainNotification> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public bool IsValid => !_notifications.Any();
}