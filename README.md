# SourceFuse, Inc. 

Assessment Instructions: 

Create an API in .NET Core / Java / NodeJs that allows you to manage customers, their contact info, and their orders for Acme Corp.

    - [x] Authentication/Authorization - API Key
    - [-] Unit tests (See Considerations section below **)
    - [x] Integration tests
    - [x] Demonstrates use of SOLID and DDD principles
    - [x] ‘docker-compose up’ should start the API, perform any DB migrations (if needed), spawn dependent resources etc.
    - [o] IaC to deploy to AWS is a bonus (See Implementation Notes **)
    - [x] Upload results to a Github link and share with Tiffany, she will send to the team for evaluation.

Implementation Notes:

- Solution was built in Visual Studio 2022 with .NET Core targeting the .NET 7 runtime.
- Container 1 exposes a .NET WebApi with Swagger and API key authentication. The demo API Key is: pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp
- Container 2 is Sql Server Express Edition.
- After running 'docker-compose up', access the OpenAPI/Swagger interface at: http://localhost/swagger/index.html, Click the 'Authorize' button and enter the API key to test the API.
- * Took a stab at bonus AWS IaC, but the config is broken at the moment. So in the interest of time, turning is as-is. Determined to get it working though! **

Considerations:

- There are know issues: https://github.com/pliebscher/SourceFuse.AcmeCorp/issues
- Database migrations are not used. The database is seeded with sample data when first created by Entity Framework.
- Unit testing async API controller methods and MSTest don't play well together. **
- Integration tests are located in AcmeCorp.WebApi.Tests solution/Project and should be executed against a running API instance.
- A more complex version of this system would include a Service layer that would include more robust Unit testing.
- For demonstration purposes and in the interest of time, only a handful of Integration tests are included.
- Exception handling is minimal.


