public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			INotificationAdapter adapter = NotificationAdapterFactory.CreateInstance(notification.AdapterType);
			
			//Violating Liskov Substitution Principle
			if(typeof(INotificationAdapter) is SmsNotificationAdapter) {
				notification.Content = notification.Content.Substring(0, 150);
			}
			
			adapter.Send(notification);
		}
	}
}