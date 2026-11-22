# React Pivot Table with Advanced Server Configuration

This quick-start sample connects a React + TypeScript Pivot Table to the ASP.NET Core Advanced Server Configuration application.

The server loads JSON, CSV, PostgreSQL, or SQLite data by using configured indexes. The React Pivot Table sends its report and actions to `/api/pivot/post`.

## Project prerequisites

Install the following before running the sample:

- Git
- Node.js
- npm
- Visual Studio 2022 or Visual Studio Code
- .NET 10 SDK

## How to run this application

### 1. Clone the repository

```sh
git clone https://github.com/SyncfusionExamples/syncfusion-pivot-table-advanced-server-configuration.git
cd syncfusion-pivot-table-advanced-server-configuration
```

### 2. Run the server application

Open the repository in Visual Studio or Visual Studio Code.

Restore and start the `PivotController` project:

```sh
dotnet restore PivotController/PivotController.csproj
dotnet run --project PivotController/PivotController.csproj
```

By default, the sample uses `http://localhost:7800`. Verify the server indexes at:

```text
http://localhost:7800/api/indexes
```

Configure data sources in `PivotController/appsettings.json` before starting the server. The sample includes JSON and CSV indexes.

### 3. Connect the React Pivot Table

The sample sets the Pivot Table to server mode in `src/App.tsx`:

```ts
const dataSourceSettings: DataSourceSettingsModel = {
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

### 4. Run the React sample

```sh
cd Samples/React
npm install
npm run dev
```

Open the local URL shown in the terminal, usually `http://localhost:5173`.
