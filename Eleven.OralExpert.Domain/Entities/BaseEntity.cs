using System.ComponentModel.DataAnnotations.Schema;
using Eleven.OralExpert.Core.Notifications;

namespace Eleven.OralExpert.Domain.Entities;

public abstract class BaseEntity : Notifiable
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    [NotMapped]
    public List<string> Notifications { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Notifications = new List<string>();
    }

    public void AddNotification(string message)
    {
        Notifications.Add(message);
    }

    public void ClearNotification()
    {
        Notifications.Clear();
    }
    
    public bool IsValid => Notifications.Count == 0;

    public void CreatedAtNow()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdatedAtNow()
    {
        UpdatedAt = DateTime.UtcNow;
    }
    
}