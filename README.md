# Advanced Server Configuration for Syncfusion Pivot Table

**Advanced Server Configuration** lets you connect a Syncfusion Pivot Table to JSON, CSV, PostgreSQL, and SQLite data sources through an ASP.NET Core server.

It helps you manage data sources as named indexes and control loading, refreshing, security, caching, and report sharing from one configuration file.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Key Benefits](#-key-benefits)
- [Prerequisites](#-prerequisites)
- [Quick Start](#-quick-start)
- [Configuration Setup](#-configuration-setup)
- [Client-side Integration](#-client-side-integration)
- [Additional Samples](#-additional-samples)
- [Licensing](#-licensing)
- [Related Documentation](#-related-documentation)

---

## 🎯 Overview

Advanced Server Configuration is an optional setup for the ASP.NET Core `PivotController` sample.

Instead of adding data directly to the Pivot Table, you register each data source as an index. The Pivot Table sends its report and actions to `/api/pivot/post`, and the server returns the processed result.

You can configure:

- JSON, CSV, PostgreSQL, and SQLite data sources
- A default index
- Automatic data refresh
- JSON and CSV field types
- Server response caching
- Database query limits
- HTTPS and Basic Authentication
- Browser CORS settings
- Saved Pivot Table reports

---

## ✨ Key Benefits

- **Easy data integration:** Use local files or database sources.
- **Flexible configuration:** Connect more than one data source.
- **Automatic updates:** Reload configured indexes at set intervals.
- **Better field handling:** Map JSON and CSV fields to the correct data type.
- **Improved security:** Control API access and browser origins.
- **Lower database load:** Limit slow queries and cache repeated responses.
- **Runtime control:** Enable, disable, reload, or delete indexes through APIs.

---

## 📦 Prerequisites

Before using Advanced Server Configuration:

- Install the .NET 10 SDK.
- Use the `PivotController` ASP.NET Core application.
- Add the Syncfusion EJ2 Pivot Table packages.
- Add a valid Syncfusion license.
- Prepare a JSON file, CSV file, PostgreSQL database, or SQLite database.

For database sources:

- Use a connection string or a named connection string.
- Use a read-only `SELECT` or `WITH` query.
- Do not include multiple statements or write operations in the query.
- Keep database passwords out of source control.

---

## 🚀 Quick Start

### 1. Configure an index

Open `PivotController/appsettings.json` and add an index under `DataServer:Indexes`.

```json
{
  "DataServer": {
    "DefaultIndexId": "Sales-Json",
    "Indexes": [
      {
        "Index": "Sales-Json",
        "Name": "Sales Analysis",
        "SourceType": "Json",
        "SourcePath": "sales-analysis.json",
        "Enabled": true,
        "AutoReload": true,
        "ReloadIntervalMinutes": 20,
        "MappingEnabled": false,
        "FieldMappings": []
      }
    ]
  }
}
```

### 2. Start the server

```powershell
dotnet restore PivotController\PivotController.csproj
dotnet run --project PivotController\PivotController.csproj
```

The sample server uses port `7800` by default.

### 3. Verify the indexes

Open:

```text
http://localhost:7800/api/indexes
```

The response shows whether each index is `Ready`, `Refreshing`, `Failed`, or `Disabled`.

---

## 🛠️ Configuration Setup

### 📂 JSON index

Use `SourceType: "Json"` for a JSON file.

The file must contain an array of records.

```json
{
  "Index": "Sales-Json",
  "Name": "Sales Analysis",
  "SourceType": "Json",
  "SourcePath": "sales-analysis.json",
  "Enabled": true,
  "AutoReload": true,
  "ReloadIntervalMinutes": 20
}
```

### 📊 CSV index

Use `SourceType: "Csv"` for a CSV file with a header row.

```json
{
  "Index": "Data-Csv",
  "Name": "Sales CSV",
  "SourceType": "Csv",
  "SourcePath": "data.csv",
  "CsvDelimiter": ";",
  "CsvDecimalSeparator": "Comma",
  "CsvThousandsSeparator": "Dot",
  "Enabled": true
}
```

| CSV option | Description |
|---|---|
| `CsvDelimiter` | Character that separates columns |
| `CsvDecimalSeparator` | `Dot` or `Comma` |
| `CsvThousandsSeparator` | `Comma`, `Dot`, or `Space` |

### 🗄️ Database index

Use `SourceType: "Database"` for a database.

```json
{
  "Index": "Sales-Db",
  "Name": "PostgreSQL Sales",
  "SourceType": "Database",
  "DatabaseType": "PostgreSQL",
  "ConnectionString": "Host=localhost;Port=5432;Database=salesdb;Username=YOUR_USER;Password=YOUR_PASSWORD",
  "Query": "SELECT * FROM salesdata",
  "Enabled": true
}
```

Supported database values include:

- `PostgreSQL`
- `Sqlite`
- `MySql`
- `MariaDB`
- `MSSQL`
- `Oracle`

The sample controller includes PostgreSQL and SQLite providers. Other databases require a matching provider implementation.

Test an existing database index:

```text
POST /api/indexes/{index}/test-connection
```

### 🔧 Common index options

| Option | Description |
|---|---|
| `DefaultIndexId` | Index used when the client request has no index |
| `Index` | Unique index name |
| `Name` | Readable index name |
| `SourceType` | `Json`, `Csv`, or `Database` |
| `SourcePath` | JSON or CSV file path |
| `Enabled` | Enables or disables the index |
| `AutoReload` | Reloads the index automatically |
| `ReloadIntervalMinutes` | Automatic reload interval |
| `MappingEnabled` | Enables custom field mappings |
| `FieldMappings` | Field names and field types |

### 🧩 Field mapping

Field mapping helps when a JSON or CSV field is detected with the wrong type.

```json
{
  "MappingEnabled": true,
  "FieldMappings": [
    { "FieldName": "ProCost", "Type": "Number" },
    { "FieldName": "Date", "Type": "Date" },
    { "FieldName": "Sector", "Type": "String" }
  ]
}
```

Available field types:

- `Number`
- `Date`
- `String`

Field mapping APIs:

| Endpoint | Purpose |
|---|---|
| `GET /api/indexes/{index}/fields` | View field types |
| `PUT /api/indexes/{index}/fields/{fieldName}` | Set a field type |
| `DELETE /api/indexes/{index}/fields/{fieldName}` | Remove a field mapping |

### ⚙️ Server settings

Configure the server in `appsettings.json`.

```json
{
  "General": {
    "Port": 7800,
    "MinimumLogLevel": "Info",
    "DataFolder": "DataSource"
  },
  "DataStorage": {
    "RetryAttempts": 3,
    "CacheSizeLimit": 100,
    "KeepDataOnRefresh": true,
    "MaxCacheItemSizeBytes": 0
  },
  "DatabaseQuery": {
    "CommandTimeoutEnabled": true,
    "CommandTimeLimit": 150
  }
}
```

| Section | Purpose |
|---|---|
| `General` | Server port, log level, and data folder |
| `DataStorage` | Retry and response cache settings |
| `DatabaseQuery` | Database query timeout |

### 🔐 Security, CORS, and HTTPS

Basic Authentication and CORS help protect the server and control which websites can call it.

```json
{
  "Security": {
    "Authorization": {
      "Enabled": true,
      "Username": "YOUR_SERVER_USER",
      "Password": "SET_A_SECRET"
    },
    "CORS": {
      "AllowOrigin": "https://pivot.example.com"
    }
  }
}
```

- Use `*` for CORS only when Basic Authentication is disabled.
- Do not store real credentials in client-side code.
- Use HTTPS for production applications.
- Restart the server after changing HTTPS settings.

Example HTTPS setting:

```json
{
  "Https": {
    "Enabled": true,
    "PfxPath": "certificates/server.pfx",
    "PfxPassword": "SET_A_SECRET",
    "Protocols": "HTTP1_AND_HTTP2"
  }
}
```

### 💾 Report sharing

Enable report sharing to save and retrieve Pivot Table reports.

```json
{
  "ReportSharingOptions": {
    "EndpointEnabled": false,
    "PathToFolder": "DataServer/reports",
    "ReportExpirationTime": 0,
    "MaxSizeOfFolder": 0,
    "AutoDeletingEnabled": false
  }
}
```

| Endpoint | Purpose |
|---|---|
| `POST /api/reportsharing/reports` | Save a report |
| `GET /api/reportsharing/reports` | List reports |
| `GET /api/reportsharing/reports/{reportId}` | Retrieve a report |
| `DELETE /api/reportsharing/reports/{reportId}` | Delete a report |

---

## 🔄 Manage and Verify Indexes

| Endpoint | Purpose |
|---|---|
| `GET /api/indexes` | List indexes and status |
| `GET /api/indexes/{index}` | Get one index status |
| `POST /api/indexes` | Create an index |
| `PUT /api/indexes/{index}` | Update an index |
| `POST /api/indexes/{index}/reload` | Reload an index |
| `POST /api/indexes/{index}/enable` | Enable an index |
| `POST /api/indexes/{index}/disable` | Disable an index |
| `DELETE /api/indexes/{index}` | Delete an index |

When the server loads successfully, the index status is `Ready`.
When an index is disabled, requests to that index return `HTTP 423`.

---

## 💻 Client-side Integration

The client uses the Pivot Table in server mode. Set `mode` to `Server` and provide the `/api/pivot/post` endpoint.

```ts
import { PivotView } from '@syncfusion/ej2-pivotview';

const pivotObj: PivotView = new PivotView({
    dataSourceSettings: {
        url: 'http://localhost:7800/api/pivot/post',
        mode: 'Server',
        rows: [{ name: 'Sector' }],
        columns: [{ name: 'EnerType', caption: 'Energy Type' }],
        values: [
            { name: 'PowUnits', caption: 'Power Units' },
            { name: 'ProCost', caption: 'Production Cost' }
        ]
    },
    height: 500,
    width: 1000,
    showGroupingBar: true,
    showFieldList: true
});

pivotObj.appendTo('#PivotTable');
```

Use field names that exist in the selected index.

To use another configured index, add the index name to the URL:

```ts
const pivotObj: PivotView = new PivotView({
    dataSourceSettings: {
        url: 'http://localhost:7800/api/pivot/post?index=Data-Csv',
        mode: 'Server',
        rows: [{ name: 'Country' }],
        columns: [{ name: 'Product' }],
        values: [{ name: 'Sales', caption: 'Sales' }]
    }
});

pivotObj.appendTo('#PivotTable');
```

If Basic Authentication is enabled, add the credentials securely at runtime:

```ts
beforeServiceInvoke: function (args: any) {
    const credentials: string = getServerCredentials();

    args.internalProperties = args.internalProperties || {};
    args.internalProperties.headers = {
        ...(args.internalProperties.headers || {}),
        'Authorization': `Basic ${btoa(credentials)}`
    };
}
```

> ⚠️ Never hard-code server passwords in browser code.

If HTTPS is enabled, use `https://` and the configured server port in the Pivot Table URL.

---

## 📚 Additional Samples

- [TypeScript sample](./Samples/TypeScript)
- [Angular sample](./Samples/Angular)
- [React sample](./Samples/React)
- [Vue sample](./Samples/Vue)
- [ASP.NET Core sample](./Samples/Core)
- [MVC sample](./Samples/MVC)
- [PivotController source](./PivotController)

---

## 📜 Licensing

Advanced Server Configuration uses commercial Syncfusion components and is subject to the Syncfusion End User License Agreement.

**Free Community License** is available for qualifying users and organizations:

- Annual gross revenue less than $1 million USD
- Five or fewer developers
- Ten or fewer employees

**Paid licenses** are required for larger organizations or teams that exceed the Community License limits.

- [Purchase Syncfusion products](https://www.syncfusion.com/sales/products)
- [Start a 30-day free trial](https://www.syncfusion.com/downloads/essential-js2)
- [Community License FAQ](https://www.syncfusion.com/products/communitylicense)
- [Full Syncfusion EULA](https://www.syncfusion.com/eula/es/)

© 2026 Syncfusion, Inc. All Rights Reserved.

---

## 🔗 Related Documentation

- [Server-side Pivot Engine](https://ej2.syncfusion.com/documentation/pivotview/server-side-pivot-engine)
- [Pivot Table getting started](https://ej2.syncfusion.com/documentation/pivotview/getting-started)
- [dataSourceSettings API](https://ej2.syncfusion.com/documentation/api/pivotview/datasourcesettings)
- [Server mode API](https://ej2.syncfusion.com/documentation/api/pivotview/datasourcesettingsmodel#mode)
- [beforeServiceInvoke event](https://ej2.syncfusion.com/documentation/api/pivotview/beforeserviceinvokeeventargs)
