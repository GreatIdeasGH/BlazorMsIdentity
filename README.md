# Blazor sample applications with Microsoft Identity Platform

## Create the app using the .NET Core CLI
To create the app you need the latest Blazor templates. You can install them for the .NET Core CLI with the following command:

`dotnet new -i Microsoft.Identity.Web.ProjectTemplates::1.19.0`

Then execute the fllowing command to create the application. Replace the placeholders in the command with the proper information from your app's overview page and execute the command in a command shell.
To create a client side only blazor wasm app, use:

`dotnet new blazorwasm --auth [SingleOrg/IndividualB2C] --framework net5.0 --calls-graph -o {APP NAME} --client-id "{CLIENT ID}" --tenant-id "{TENANT ID}"`

To also create a blazor wasm hosted option, use:

`dotnet new blazorwasm -hosted --auth [SingleOrg/IndividualB2C] --framework net5.0 --calls-graph -o {APP NAME} --client-id "{CLIENT ID}" --tenant-id "{TENANT ID}"`

You can also discover more options by providing the following command:

`dotnet new blazorwasm -h`

Further instructions to sign in users and call a protected API from a Blazor WebAssembly app can be found [here](https://docs.microsoft.com/en-us/azure/active-directory/develop/tutorial-blazor-webassembly)

## Configuring code from an existing application
Use the following commands to install the MS Identity Platform CLI:
 
`dotnet tool install -g msidentity-app-sync` which has instructions [here](https://github.com/AzureAD/microsoft-identity-web/tree/master/tools/app-provisioning-tool)

The following configures code with an existing application.
```
dotnet new blazorwasm --auth SingleOrg

msidentity-app-sync [--tenant-id <tenantId>] --client-id <clientId>
```
Same thing for an application calling Microsoft Graph
```
dotnet new blazorwasm --auth SingleOrg --calls-graph

msidentity-app-sync [--tenant-id <tenantId>] --client-id <clientId>
```
