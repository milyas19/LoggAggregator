# LoggAggregator
Log Aggregator is an API responsible to collect log data from servers and stored into the database. This API is implemented by using Microsft .Net Core which is a cross-platform open-source framework.

# Tech/framework used
- Asp.Net Core (API)
- MediatR (is an open-source implementation of the mediator pattern, which helps us to reduce coupling and isolate the concerns of requesting the work)
- Swagger (API testing and documentation)
- ReactJs (Consumes the API endpoints and present data in browser)
- EntityFramework Core (To perform database operation)

# Features
- By calling the API-endpoint, we can perform different operations
  - CreateLog
  - Get list of logs
  - Get log by an id
  - List of severity-level in order to filter the logs

# API-Endpoints
In order to test API, Please Run the project and it will open swagger as it is set as default in launchSettings.json in API project.
-SwaggerURL: (http://localhost:{portnumber}/swagger/ui/index.html)
- BaseUrl: http://localhost:{portnumber}
- GET List: /api/loggaggregator
- GET By Id: /api/loggaggregator/{id}
- GET Severity-Level: /api/loggaggregator/severity

# Diverse
- Update the ConnectionStrings in appsettings.json in API and Persistence project
- In this project, a SQLServer is being used.

# Future Work/ Improvements
- Can filter logs by date/ month
- Can write unit-tests more and better
- Can store data not only in SQL but json, Azure blob can be used.
