//We shall use the Repository Pattern to use and inteface to break the tight coupling
//between the higher level "Poller" component and the low level data access logic

public Interface INotificationsRepository {
	Notification[] Retrieve(int batchSize);
}

public class Poller {
	protected int batchSize;
	protected INotificationsRepository repo;

	public Poller(int batchSize, INotificationsRepository repo)
	{
		this.batchSize = batchSize;
		this.repo = repo;
	}

	public void Start() {
		while(continuePolling) {
			Notification[] batch = repo.Retrieve(this.batchSize); //Poller now depends on an abstraction (INotificationsRepository) instead.
			if(batch.Length > 0) {
				Publisher publisherInstance = new Publisher(batch);
				publisherInstance.Publish();
			}

			Thread.Sleep(15000);
		}
	}

	//No need for a specific PollNotificationBatch() method now.
}

//Hence now we can implement INotificationsRepository.Retrieve for any datasource like so

public class SqlNotificationsRepository : INotificationsRepository {
	public Notification[] Retrieve(int batchSize) {
		SqlConnection connection = new SqlConnection("CONNECTION STRING HERE");
		SqlCommand command = new SqlCommand(connection);
		command.CommandText = "TSQL TO SELECT TOP (BatchSize) FROM NotificationsTable";
		SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
		DataTable table = new DataTable();
		dataAdapter.Fill(table);

		/* Implementation for mapping and returning Notification[] from DataTable */
	}
}

public class RedisNotificationsRepository : INotificationsRepository {
	public Notification[] Retrieve(int batchSize) {
		/* Implementation for querying Redis and returning Notification[] using a Redis client library*/
	}
}

//Afterwards we can INJECT (pass) either implementation to the Poller constructor as the "repo" DEPENDENCY (parameter).
//This is called "Constructor Injection" a way of implementing "Dependency Injection (DI)" a form of "Inversion of Control (IoC)",
//The code below is using "Poor Man's Dependancy Injection"

public class NotificationApplication {
	public static void Main(string[] args) { //In this case the "Main" method is the Application seam / composition root for DI
		int batchSize = 100;
		INotificationsRepository repo = new RedisNotificationsRepository();
		//Every time you use the "new" keyword with an abstraction (interface, abstract class etc.), you create a tight coupling.

		Poller pollerInstance = new Poller(batchSize, repo); //(Poor Man's DI) Since we can't "afford" an IoC container for simplycity's sake.
		poller.Start();
	}
}

//To solve the above tight coupling problem we'll need to use "Inversion of Control" via "Dependency Injection"
//A topic for another day! :D