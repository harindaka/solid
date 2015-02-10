public class Notification {
	public string Content { get; set; }
	public NotificationTypes NotificationType { get; set; } //Enum value can be SMS, Email
}

public class NotificationApplication {
	public static void Main(string[] args) {
		bool forever = true;
		int batchSize = 100;
		Poller pollerInstance = new Poller(batchSize);
		poller.Start();
	}
}

public class Poller {
	protected int batchSize;
	protected continuePolling = true;

	public Poller(int batchSize) { this.batchSize = batchSize; }

	public void Start() {
		while(continuePolling) {
			Notification[] batch = PollNotificationBatch(this.batchSize);
			if(batch.Length > 0) {
				Publisher publisherInstance = new Publisher(batch);
				publisherInstance.Publish();
			}

			Thread.Sleep(15000);
		}
	}

	private Notification[] PollNotificationBatch() { /*Implementation*/ }
}

public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			if(notification.Type == NotificationTypes.Sms) {
				SmsAdapter adapter = new SmsAdapter();
				adapter.Send(notification);
			}
			else {
				EmailAdapter adapter = new EmailAdapter();
				adapter.Send(notification);
			}
		}
	}
}

public class SmsAdapter {
	public Send(Notification notification) { /*Implementation*/ }
}

public class EmailAdapter {
	public Send(Notification notification) { /*Implementation*/ }
}