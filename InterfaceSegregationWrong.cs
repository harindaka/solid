public interface INotificationAdapter {
	public void Send(Notification notification);
	public void UpdateDeliveryReport(DeliveryResult result);
	//Assume Delivery Reports / Read Receipts are accepted by a service which invokes INotificationAdapter.UpdateDeliveryReport
}

public class SmsAdapter : INotificationAdapter {
	public Send(Notification notification) { /* Implementation for sending SMS */ }
	public void UpdateDeliveryReport(DeliveryResult result) { /* Implementation for updating SMS delivery reports */ }
}

public class EmailAdapter : INotificationAdapter {
	public Send(Notification notification) { /* Implementation for sending SMS */ }
	public void UpdateDeliveryReport(DeliveryResult result) { /* Implementation for updating Email read receipts */ }
}

public class ApnsAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation for sending to Apple Push Notifications*/ }
	public void UpdateDeliveryReport(DeliveryResult result) { return; } //Assuming APNS does not send delivery reports implementing this method should not be forced.
}

public class GcmAdapter : INotificationAdapter {
	public Send(Notification notification) { /*Implementation for sending Google Cloud Messages*/ }
	public void UpdateDeliveryReport(DeliveryResult result) { return; } //Assuming GCM does not send delivery reports implementing this method should not be forced.
}

//Hence INotificationAdapter is now a polluted interface.