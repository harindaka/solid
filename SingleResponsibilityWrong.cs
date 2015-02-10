public class Notification {
	public string Content { get; set; }
	public NotificationTypes NotificationType { get; set; } //Enum value can be SMS, Email
}

public class GodClass //One class to rule them all :D
{
	public static void Main(string[] args) {
		bool continuePolling = true
		int batchSize = 100;
		while(continuePolling) {
			Notification[] batch = PollNotificationBatch(batchSize);
			foreach(Notification notification in batch) {
				if(notification.Type == NotificationTypes.Sms) {
					SendSMS(notification);
				}
				else {
					SendEmail(notification);
				}
			}
			
			Thread.Sleep(15000); //Really bad I know :D
		}
	}

	public static Notification[] PollNotificationBatch(int batchSize) { /*Implementation*/ }
	public static void SendSMS() { /*Implementation*/ }
	public static void SendEmail() { /*Implementation*/ }
}