# Project Title

Onyx Product coding challenge solution.

## Description

Project follows Clean Arhictecture principals and consequently you should consider this when reviewing solution.
Mediatr pattern is used to enable loose coupling amongst the code features

## Getting Started
VS 2022 
ASP.NET CORE V8
LOCAL SQLSERVER
AUTHENTICATION USING NEW V8 Microsoft.AspNetCore.Identity 
	The curl session follows a register & login to get bearer token to enable working with secured functions
	(NB use swagger to review full list of functions https://localhost:<YOUR_PORT>/swagger/index.html

Root repo folder contains a curl_session.txt file with listing for a session that demonstrates the functions
change ports etc to enable running on your machine
Note EF Migrations will create a db in your local sql server each time you run app (for convenience)
Identity server is using in memory db so again any info is lost each time you restart.
Integration test is using "Inmemory" db in place of the sql server.

### Dependencies

* Local sql server is required...see connection string in appsettings
* Windows 11

### Installing

* Clone repo from github 
* open in vs2022
* set api project to start

### Executing program

* f5 Run 
* open a bash session 
* run the curl_session requests

* run the unit tests in Test explorer
* Prior to running Integration Tests change the environment to "IntegrationTest"
	...preprocessor is disabling(removing) the Authorize dataannotation in Product controller.

## Help



## Authors



## Version History


## License



## Acknowledgments

