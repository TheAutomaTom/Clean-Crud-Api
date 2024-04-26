# Clean Crud Architecture
### Just a _"Basic C.R.U.D. Api"_ using Clean Architecture principles

<small>Version: 240417</small>

<small>Author:</small>
- Thomas Grossi 
- Nashville, TN 
- TheAutomaTom@gmail.com 
- https://www.SurrealityCheck.org



<hr/>

## Initial Setup

### Recommended Tooling

### Caching

- Redis Insight cache browsing gui

	https://redis.io/insight/

### EF Core

##### Technical references

- Entity Framework Code-First 
 
	https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

- GraphQL by HotChocolate 

	https://chillicream.com/docs/hotchocolate/v13/get-started-with-graphql-in-net-core
			
- Bogus data generator 		
	https://github.com/bchavez/Bogus

- Testcontainers

	https://www.atomicjar.com/category/testcontainers/


- 

##### Standard operating procedure

1. In PackageManager window, select .Persistence as "Default project" on dropdown menu.
1. EntityFrameworkCore\add-migration initial_Cruds -o Migrations/Cruds -Context CrudContext

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

## References

GraphQL Tutorial by SingletonSean

https://www.youtube.com/watch?v=iOQ74eYU2U4&list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj&ab_channel=SingletonSean

ELK Stack

https://github.com/deviantony/docker-elk/blob/main/elasticsearch/config/elasticsearch.yml

