using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;
using System;

public class NotificationManager : MonoBehaviour
{
    void Awake()
    {
        RequestAuthorization();
        RegisterChannel();
    }

    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    public void RegisterChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification(string title, string text, int fireTimeInSeconds, string smallIcon, string largeIcon)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddSeconds(fireTimeInSeconds);
        notification.SmallIcon = smallIcon;
        notification.LargeIcon = largeIcon;

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
}
