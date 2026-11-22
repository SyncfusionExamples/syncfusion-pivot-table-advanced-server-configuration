# Angular Pivot Table with Advanced Server Configuration

This quick-start sample connects an Angular Pivot Table to the ASP.NET Core Advanced Server Configuration application.

The server loads JSON, CSV, PostgreSQL, or SQLite data by using configured indexes. The Angular Pivot Table sends its report and actions to `/api/pivot/post`.

## Project prerequisites

Install the following before running the sample:

- Git
- Node.js
- npm
- Angular CLI
- Visual Studio 2022 or Visual Studio Code
- .NET 10 SDK

## How to run this application

### 1. Clone the repository

```sh
git clone https://github.com/SyncfusionExamples/syncfusion-pivot-table-advanced-server-configuration.git
cd syncfusion-pivot-table-advanced-server-configuration
```

### 2. Run the server application

Restore and start the `PivotController` project:

```sh
dotnet restore PivotController/PivotController.csproj
dotnet run --project PivotController/PivotController.csproj
```

By default, the sample uses `http://localhost:7800`. Verify the configured indexes at:

```text
http://localhost:7800/api/indexes
```

Configure JSON, CSV, or database sources in `PivotController/appsettings.json` before starting the server.

### 3. Connect the Angular Pivot Table

The sample sets the Pivot Table to server mode in `src/app/app.ts`:

```ts
this.dataSourceSettings = {
    url: 'http://localhost:7800/api/pivot/post',
    mode: 'Server',
    type: 'JSON',
    rows: [{ name: 'Sector' }],
    columns: [{ name: 'EnerType', caption: 'Energy Source' }],
    values: [
        { name: 'PowUnits', caption: 'Power Units' },
        { name: 'ProCost', caption: 'Production Cost' }
    ]
};
```

To use another configured index, add the index name to the endpoint:

```ts
url: 'http://localhost:7800/api/pivot/post?index=Data-Csv'
```

If HTTPS or a different server port is enabled, update the endpoint URL with the active server address.

### 4. Run the Angular sample

```sh
cd Samples/Angular
npm install
npm start
```

Open `http://localhost:4200/` in the browser.
