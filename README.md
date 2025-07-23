
## ✅ Paso 0: Instalar paquetes NuGet necesarios
### En la capa **Infrastructure**:

``` V.8
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```
### En la capa **Presentation**:

```V.8
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
```
```V.13
Install-Package AutoMapper
```
### En la capa **Domain**:

```V.8
Install-Package Microsoft.EntityFrameworkCore
```



### En la capa **Application**:
```
Install-Package AutoMapper
```






## 🔗 Paso 1: Agrega la cadena de conexión

Edita el archivo `appsettings.json` en el proyecto de presentación:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TechnicalTestDB_Greg;User Id=sa;Password=TiDeve;MultipleActiveResultSets=true;Trust Server Certificate=true"
  }
}
```

---

## ⚙️ Paso 2: Configura la inyección del DbContext

Edita el archivo `Program.cs` en el mismo proyecto y agrega:

```csharp
builder.Services.AddDbContext<TechnicalTestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

Debe ir **antes de**:

```csharp
var app = builder.Build();
```

---

## 🧱 Paso 3: Ejecuta el Scaffold

Abre la **Package Manager Console** y asegúrate de seleccionar como proyecto de inicio el de presentación (`WebTechTestGreg`).

Ejecuta:

```powershell
Scaffold-DbContext "Server=.;Database=TechnicalTestDB_Greg;User Id=sa;Password=TiDeve;TrustServerCertificate=true;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -Context TechnicalTestDbContext -OutputDir "..\DOMAIN\Models" -ContextDir "DbContexts" -Namespace "DOMAIN.Models" -ContextNamespace "INFRASTRUCTURE.DbContexts" -NoOnConfiguring -Force
```

---

## ✅ Resultado Esperado

- Las **entidades (modelos)** se generarán en: `DOMAIN/Models`
- El **DbContext** se generará en: `INFRASTRUCTURE/DbContexts`
- La aplicación usará la cadena de conexión desde `appsettings.json`
- El `DbContext` no contendrá una cadena “quemada” (gracias a `-NoOnConfiguring`)