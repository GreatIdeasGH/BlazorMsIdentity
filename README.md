## Blazor sample applications with Microsoft Identity Platform

> Use the following commands to install the MS Identity Platform CLI:
>
> `dotnet tool install -g msidentity-app-sync` which has instructions [here](https://github.com/AzureAD/microsoft-identity-web/tree/master/tools/app-provisioning-tool)

## Configuring code from an existing application

The following configures code with an existing application.
```
dotnet new webapp --auth SingleOrg

msidentity-app-sync [--tenant-id <tenantId>] --client-id <clientId>
```
Same thing for an application calling Microsoft Graph
```
dotnet new webapp --auth SingleOrg --calls-graph

msidentity-app-sync [--tenant-id <tenantId>] --client-id <clientId>
```
