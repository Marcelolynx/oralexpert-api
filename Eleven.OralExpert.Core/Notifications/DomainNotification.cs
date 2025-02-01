namespace Eleven.OralExpert.Core.Notifications;

public class DomainNotification : Notification
{
    public DomainNotification(string property, string message)
        : base(property, message)
    {
    }
}