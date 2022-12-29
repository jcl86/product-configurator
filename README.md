# Lumasuite Product Configurator

[![Deploy site to Netlify](https://github.com/jcl86/product-configurator/actions/workflows/deploy-site-to-netlify.yaml/badge.svg)](https://github.com/jcl86/product-configurator/actions/workflows/deploy-site-to-netlify.yaml)

This is a Blazor wasm application that allows you to customize your own lumasuite case

The application is hosted here:

https://design-your-lumasuite-case.netlify.app/


# Migrations

### AplicationContext

````
dotnet ef migrations add <MigrationName> --project src/Application/ProductConfigurator.Core/ProductConfigurator.Core.csproj --startup-project src/Web/ProductConfigurator.Host/ProductConfigurator.Host.csproj --context ApplicationContext -o Database/Migrations/Application -v
````

### AdminContext

````
dotnet ef migrations add <MigrationName> --project src/Application/ProductConfigurator.Core/ProductConfigurator.Core.csproj --startup-project src/Web/ProductConfigurator.Host/ProductConfigurator.Host.csproj --context AdminContext -o Database/Migrations/Admin -v
````