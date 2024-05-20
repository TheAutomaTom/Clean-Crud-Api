# Clean Crud Architecture
### Just a _basic C.R.U.D. Api"_ using Clean Architecture principles

<small>Version: 240417</small>

<small>Author:</small>
- Thomas Grossi 
- Nashville, TN 
- TheAutomaTom@gmail.com 
- https://www.SurrealityCheck.org

<hr/>

### Recommended Development Tooling

#### MsSqlServer

- Azure Data Studio

	https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15


#### Elastic for Crud detail blobs

- Elasticvue browser extension

	https://chromewebstore.google.com/detail/elasticvue/hkedbapjpblbodpgbajblpnlpenaebaa

#### Distributed Caching

- Redis Insight

	https://redis.io/insight/

#### Postgress for Keycloak configuration

- Azure Data Studio Extension: PostgresSQL 

	https://github.com/Microsoft/azuredatastudio-postgresql/


<hr/>

### Container environment setup

#### For CCA Api containers:

1. Open a terminal at `.\CCA.TestSetup\Container-Manual-Setup`	
1. Run `docker-compose up -d`

##### EF Core Migrations

###### Initial Setup

1. In PackageManager window, select .Persistence as "Default project" on dropdown menu.
1. Run `EntityFrameworkCore\add-migration initial_Cruds -o Migrations/Cruds -Context GeneralDbContext`

	###### Reapplying Updates
1. Run `EntityFrameworkCore\add-migration -o Migrations/Cruds -Context GeneralDbContext`
1. Specify a unique name for this migration.
1. 



#### For Elastic and Kibana, this repo is uses a fork of [deviantony/docker-elk](https://github.com/deviantony/docker-elk/blob/main/elasticsearch/config/elasticsearch.yml):

1. Open a terminal at `.\CCA.TestSetup\Container-Manual-Setup\fork-docker-elk`
1. Run `docker-compose up setup`
1. Run `docker-compose up -d`	

	<small>_For further documentation, refer to `.\CCA.TestSetup\Container-Manual-Setup\fork-docker-elk\README.md`_</small>

1. Run the app to ensure the logging index is created.

#### Local Kibana setup
1. Open a browser to `http://localhost:5601` to view Kibana

	Log in with default user `elastic` and pass `changeme`
1. Click `Analytics/ Discorver`
1. Click the `V` (down carrot) in the light blue box on the left that shold say `logs-*` by default.
1. Click `Create data view` in the new menu.	
1. Add an index pattern that matches the prefix of your index + *. Ex: `cca-*`

#### Elasticvue GUI

1. Add cluster
1. Select `Basic Auth` and use default user `elastic` and pass `changeme`	
1. Uri `http://localhost:9200`


#### Redis Insight

1. Add Redis database
1. Host: `localhost`
1. Port: `6379`
1. Username: [none/ leave empty]
1. Password: `Admin123!`

#### Azure Data Studio for MsSqlServer

1. New Connection
1. Connection type: Microsoft SQL Server
1. Select `Connection String`
1. Refer to Appsettings.Development.json.  Example:
	 
	`Server=host.docker.internal,1433;User Id=sa;Password=Admin123!;TrustServerCertificate=True;`

#### Azure Data Studio for PostgresSQL

1. Add ADS extention: PostgresSQL
	
	https://github.com/Microsoft/azuredatastudio-postgresql/

1. New Connection
1. Connection type: PostgresSQL
1. Server name: `localhost`
1. Authentication type: `Password`
1. User name: `admin` (_or whatever you specified in the `.env` file_)
1. Password: `Admin123!` (_or whatever you specified in the `.env` file_)
1. Name(optional): `Clean Crud Postgres`
		

#### For Auth realted containers (Keycloak & Postgres):

1. Open a terminal at `.\CCA.TestSetup\Container-Manual-Setup\keycloak`	
1. Run `docker-compose up -d`

	<small>_Keycloak will take about 1 full minute to be available.  The logs will help indicate when set up is complete._</small>

##### Connect to the Postgres server



##### Create a Keycloak client for user management

_With the `Master` realm selected..._
1. Create a new Client
1. Note the Id you assign.
1. Enable `Client authentication`
1. Enable `Service account roles`
1. Click on Clients/ \{your newly created client}
1. Select "Credentials" tab and note `client secret` for future use.

##### Create a Keycloak client for user interactions

1. Create a new Realm, and use it in the following steps.
1. Create a new Client
	1. Turn on "Client Authentication"
	1. Turn on "Authorization"
	1. Click on Clients/ \{your newly created client}
	1. Select "Credentials" tab and note `client secret` for future use.

1. Create Client Roles
	1. Select "Roles" tab.
	1. Add client roles per the `Keycloak Configuration` section below.
1. Create Users...

	_Use CCA's integrated api to create users_

#### Keycloak Configuration

| **Item**				| Key		| Value								             | Note													|
|	--- 																			 |														|
| **Realm**				| Name		| `Clean-Crud`	   						         |														|
| **Api Client**		| Id		| `clean-crud-api`							     |														|
|						| Name		| `Clean Crud Api`							     |														|
|						| Secret	| `l10ptCQ2wRUgacxK6Ob9tdGSxVy4bgwb` | After client is created & saved, look in its "Credentials" tab.	|
| **Ui Client**			| Id		| `clean-crud-ui`							     |														|
|						| Name		| `Clean Crud Ui`							     |														|
|						| Secret	| `sh5vuqdnjmLzzCmRCLDkYlHUhn2c4893` | After client is created & saved, look in its "Credentials" tab.	|
| **Ui Client Role 1**	| Name		| `Unregistered`				 		||
|                       | Desc		| Default privilege for unknown users.	||
| **Ui Client Role 2**	| Name		| `Registered`							||
|                       | Desc		| Typical user access.					||
	

<hr/>


### Technical notes
 
#### On ValueTask as used in Handler return types
	
Tasks are references allocated to The Heap.  We label a return type as a async Task<T> in order to permit awaiting for other operations to complete.  Most often, the actual return will be just a T.

ValueTasks are Discriminated Unions which can represent one of two things: <T> or Task<T>.  This means we can still return an actual Task<T> or avoid allocating Heap memory for a Task when methods' await minor operations, such as checking a cache.



<hr/>

## Technical Notes

### Glossary

#### Taxonomy

- The suffix `Spec` indicates predictably structured data typical of a relational database.  This is an abbreviation of "specification."
- The suffix `Detail` indicates blobs.

- `IManage...` indicates a service is capable of read and write operations on a domain.

- `ISend...` indicates outbound operations to a service outside of this api's domain.

#### Auth and Accounts

- `Accounts` have a username and password and can log in to use this service.  An `Account` has a `User`.
- `Users` are Auth related entities.  This term originates in Keycloak's documentation.


## References

- `Keycloak.AuthServices` Nuget

	https://nikiforovall.github.io/keycloak-authorization-services-dotnet/configuration/configuration-keycloak.html

- `Entity Framework` Code-First Guide
 
	https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

- `HotChocolate` GraphQL Nuget

	https://chillicream.com/docs/hotchocolate/v13/get-started-with-graphql-in-net-core
	
	Nice GraphQL walkthrough series by `SingletonSean`
	
	https://www.youtube.com/watch?v=iOQ74eYU2U4&list=PLA8ZIAm2I03g9z705U3KWJjTv0Nccw9pj&ab_channel=SingletonSean
				
- `Bogus` data generator 		
	https://github.com/bchavez/Bogus

- `Testcontainers`

	https://www.atomicjar.com/category/testcontainers/

- Distributed Caching by `Redis`
 
	https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-8.0#distributed-redis-cache

- .Net native output caching

	https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-8.0
	

- Middleware chat

	https://www.youtube.com/watch?v=TqCshF0o0nE&ab_channel=ShawnWildermuth

- Containerized ELK Stack by `deviantony/docker-elk`

	https://github.com/deviantony/docker-elk/blob/main/elasticsearch/config/elasticsearch.yml

	
## TODO

#### API

- Flush out Service Result returns
	- How about one Error[] that could be an Exception, ValidationError, or custome ErrorMessage?
	- `Dictionary<ErrorType, object>`?
	- Is the Exception Middleware really doing anything well?  Is there any reason not to skip it?
- Add Search endpoints that use Elasticsearch
- Add a hosted service to that runs on a timer or by RabbitMq to generate a Crud Report (to MongoDb?)
- User Management has a lot of features left to build
- Add some extra element to users, like tracking their recent usage history.
- Write tests!
- How could custom Json converter be handy?  Maybe creating custom table view configurations.  I could make a demo Choose-your-own-adventure.
- Add load testing/ benchmarking.
- Add a Twilio interface?
- 

#### UI

- Add user creation/ login/ logout features.
- Write tests!
- Consolidate logging to Kibana.
- Add stuff to interact with Crud endpoints (fake work to show off an interface).
- Add Google Ads, or at least create a demo.
- DataTagging to Kibana?  Is that a thing?
