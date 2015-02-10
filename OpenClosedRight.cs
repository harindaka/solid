//Adapter pattern
public interface INotificationAdapter {
	public void Send(Notification notification);
}

public class SmsAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation*/ }
}

public class EmailAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation*/ }
}

//Factory Method pattern
public static class NotificationAdapterFactory {
	public static INotificationAdapter CreateInstance(string type)
	{
		return (INotificationAdapter)Activator.CreateInstance(type); //This is slow I know :D but premature optimization is the root of all evil.
	}
}

public class Notification {
	public string Content { get; set; }
	public string NotificationAdapterType { get; set; } //We replace NotificationType Enum with this property
}

//The true meaning of KISS (My Intepretation). In Comparison the Publisher class is much simpler now.
public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			INotificationAdapter adapter = NotificationAdapterFactory.CreateInstance(notification.AdapterType); //Service Locator Pattern is bad I know :D
			adapter.Send(notification);
		}
	}
}

//Now we are able to add any new adapters like so without modifying the existing code. (open for extension closed for modification)
public class ApnsAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation for sending to Apple Push Notifications*/ }
}

public class GcmAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation for sending Google Cloud Messages*/ }
}

//The true meaning of YAGNI (My Intepretation). We only implement the adapters we require.

//We can go one step further and implement this as a plugin based system where each adapter is a plugin assembly (dll) loaded dynamically
//This would also give us the option of just dropping the plugins in a folder to support a new adapter
//and to tare down the adapter process gracefully releasing any system resources if the adapter's Send method does not respond withing a certain timeout period. 