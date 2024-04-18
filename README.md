# TheAutomaTom's Clean Architecture Template
### Because getting started is the hard part. 

<small>Version: 240417</small>

<small>Author:</small>
- Thomas Grossi 
- Nashville, TN 
- TheAutomaTom@gmail.com 
- https://www.SurrealityCheck.org



<hr/>

## Initial Setup

### Containers

- Launch `Docker for Windows`.
- Open an command prompt at the directory containing `compose.yaml`.
- Run `docker compose up -d`.

#### Verify Kibana Connectivity

- Go to `http://localhost:5601/app/home/`
	- Click the `☰` mushroom-burger button in the top left, then select `Management/ Stack Management`
	- Select `Index Management`
	- Observe your created logging index with configured primary shards and replicas
	- Note the sane of your index for the next step.
- Configure Logging Stream
	- Click the `☰` mushroom-burger button in the top left, then select `Analytics/ Discover`		
	- Select `Create data view``
		- Set `Name` as appropriate
		- Set `Index pattern` to `$"{name-of-your-index-before-date}-*"` __(`*` is a wildcard*)__
					-	Example: `elk8-lab-api-*`
		- Select `Save Data View`
- For an example of searching for a specific error
	- In Swagger, execute `ElasticsearchClient8/IntentionallyThrow?someParameter=666`
	- In Kibana, search for `IntentionallyThrow`
	- Observe the results!


### EF Core

##### Tech reference

- Entity Framework Code-First : https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

##### Standard operating procedure

1. In PackageManager window, select .Data project as "Default project" on dropdown menu.
1. EntityFrameworkCore\add-migration initial_OutboundStaging -o Migrations/OutboundStaging -Context OutboundContext
1. EntityFrameworkCore\add-migration initial_SubscriberContext -o Migrations/Subscribers -Context SubscriberContext

##### Example docker connection string

- Server=172.25.128.1,1433;User Id=sa;Password=ayeCiEs2k24!;TrustServerCertificate=True;

You may need to replace `172.25.128.1` with your own ip address.  From Docker's perspective, this is its Host's Ip4 number.

1. Open a `cmd` terminal
1. Run `ipconfig`
1. In this case, it was labeled as the "Ethernet adapter vEthernet (WSL)" adapter.  
- WSL stands for "Windows Subsystem for Linux" and is the preferred tech to use Docker on Windows.  
- You may be using the Hyper-V alternative, so the label for the adapter could be different.

<hr/>

## Technical Notes

### On ValueTask as used in Handler return types
	
Tasks are references allocated to The Heap.  We label a return type as a async Task<T> in order to permit awaiting for other operations to complete.  Most often, the actual return will be just a T.

ValueTasks are Discriminated Unions which can represent one of two things: <T> or Task<T>.  This means we can still return an actual Task<T> or avoid allocating Heap memory for a Task when methods' await minor operations, such as checking a cache.

<hr/>