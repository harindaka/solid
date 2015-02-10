//Assume that the notifications are queued in a Microsoft SQL Server table
public class Poller {
	protected int batchSize;

	public Poller(int batchSize) { this.batchSize = batchSize; }

	public void Start() {
		/* Implementation for calling PollNotificationBatch() and continuously poll */
	}

	private Notification[] PollNotificationBatch()
	{
		//Here we see that the hight level component "Poller" depends on (tight coupling) the Microsoft Sql Client library.

		SqlConnection connection = new SqlConnection("CONNECTION STRING HERE");
		SqlCommand command = new SqlCommand(connection);
		command.CommandText = "TSQL TO SELECT TOP (BatchSize) FROM NotificationsTable";
		SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
		DataTable table = new DataTable();
		dataAdapter.Fill(table);

		/* Implementation for mapping and returning Notification[] from DataTable */
	}
}

//Assume after going live you needed to change the underlying datasource to Redis or something else i.e. a RESTful service.
//Hence now you have to modify the Poller.PollNotificationBatch implementation.
//This is since Poller depends on the low level data access logic (Microsoft Sql Client library).

public class Poller {
	protected int batchSize;

	public Poller(int batchSize) { this.batchSize = batchSize; }

	public void Start() {
		/* Implementation for calling PollNotificationBatch() and continuously poll */
	}

	private Notification[] PollNotificationBatch()
	{
		/* Implementation for querying Redis using a Redis client library */
		
		/* Implementation for mapping and returning Notification[] from DataTable */
	}
}
