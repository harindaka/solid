//Let's consider a previous example of the Publisher class
public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			//Note the repetition of code/functionality

			if(notification.Type == NotificationTypes.Sms) {
				SmsAdapter adapter = new SmsAdapter();
				adapter.Send(notification);
			}
			else if(notification.Type == NotificationTypes.Email) {
				EmailAdapter adapter = new EmailAdapter();
				adapter.Send(notification);
			}
			else {
				ApnsAdapter adapter = new ApnsAdapter();
				adapter.Send(notification);
			}
		}
	}
}

//Compare it with the refactored class which is SOLID compliant

public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			//No repetition of code here :D
			INotificationAdapter adapter = NotificationAdapterFactory.CreateInstance(notification.AdapterType);
			adapter.Send(notification);
		}
	}
}

//Don't repeat yourself.