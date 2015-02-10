public class SmsAdapter : INotificationAdapter {
	public Send(Notification notification) {
		notification.Content = notification.Content.Substring(0, 150);
		/* Implementation for sending SMS */
	}
}

public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		//Hence we do not treat the SmsAdapter any differently
		foreach(Notification notification in this.batch) {
			INotificationAdapter adapter = NotificationAdapterFactory.CreateInstance(notification.AdapterType); //Service Locator Pattern is bad I know :D
			adapter.Send(notification);
		}
	}
}