public interface INotificationAdapter {
	public void Send(Notification notification);	
}

public interface IDeliveryVerifiableNotificationAdapter : INotificationAdapter { //We extend (inherit) INotificationAdapter via another interface
	public void UpdateDeliveryReport(DeliveryResult result);	
}

public class SmsAdapter : IDeliveryVerifiableNotificationAdapter { //Implement IDeliveryVerifiableNotificationAdapter since delivery reports are supported.
	public Send(Notification notification) { /* Implementation for sending SMS */ }
	public void UpdateDeliveryReport(DeliveryResult result) { /* Implementation for updating SMS delivery reports */ }
}

public class EmailAdapter : IDeliveryVerifiableNotificationAdapter { //Implement IDeliveryVerifiableNotificationAdapter since read receipts are supported.
	public Send(Notification notification) { /* Implementation for sending SMS */ }
	public void UpdateDeliveryReport(DeliveryResult result) { /* Implementation for updating Email read receipts */ }
}

public class ApnsAdapter : INotificationAdapter { //Not forced to implement UpdateDeliveryReport
	public Send(Notification notification) { /*Implementation for sending to Apple Push Notifications*/ }
}

public class GcmAdapter : INotificationAdapter { //Not forced to implement UpdateDeliveryReport
	public Send(Notification notification) { /*Implementation for sending Google Cloud Messages*/ }
}