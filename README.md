# SourceFuse, Inc. 

Assessment Instructions: 

Create an API in .NET Core / Java / NodeJs that allows you to manage customers, their contact info, and their orders for Acme Corp.

    - Authentication/Authorization - API Key
    - Unit tests
    - Integration tests
    - Demonstrates use of SOLID and DDD principles
    - ‘docker-compose up’ should start the API, perform any DB migrations (if needed), spawn dependent resources etc.
    - IaC to deploy to AWS is a bonus
    - Upload results to a Github link and share with Tiffany, she will send to the team for evaluation. 

Implementation Notes:

- Solution was built in Visual Studio 2022 targeting the .net 7 runtime.
- Container 1 exposes a .net WebApi with Swagger and API key authentication. The demo API Key is: pgH7QzFHJx4w46fI~5Uzi4RvtTwlEXp
- Container 2 is Sql Server Express Edition.

Considerations:

- Database migrations are not used. The database is seeded with sample data when first created by Entity Framework.
- Unit testing Async API controller methods in MS Test does not work so only end-to-end integration tests are inlcuded.
- For demonstration purposes and in the interest of time, only a handful of Integration are included.
- Exception hanling is minimal.
