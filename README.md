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

Execution Notes:

- Solution was built in Visual Studio 2022 targeting the .net 7 runtime.
- Container 1 exposes a .net WebApi with Swagger and API key authentication.
- Container 2 is Sql Server Exoress Edition.
