public class Publisher {
	protected Notification[] batch;

	public Publisher(Notification[] batch) { this.batch = batch; }

	public void Publish() {
		foreach(Notification notification in this.batch) {
			if(notification.Type == NotificationTypes.Sms) { //Enums are a code smell
				SmsAdapter adapter = new SmsAdapter(); //The "new" keyword is a code smell
				adapter.Send(notification);
			}
			else if(notification.Type == NotificationTypes.Email) {
				EmailAdapter adapter = new EmailAdapter();
				adapter.Send(notification);
			}
			else {
				//To add new adapters we need to modify the existing code like so
				ApnsAdapter adapter = new ApnsAdapter();
				adapter.Send(notification);
			}
		}
	}
}

//Many say that this is YAGNI or KISS. I disagree. This is just bad design.