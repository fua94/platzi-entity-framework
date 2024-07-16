Comando para instalar la herramienta de EF

`dotnet tool install --global dotnet-ef`

Comando para instalar EF Design

`dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.5`

Cada migración debe de tener un nombre descriptivo

`dotnet ef migrations add InitialCreate`

Si queremos utilizar migrations en producción debemos hacerlo una vez que se haya terminado el esquema, o sea mientras no hayan datos.
Cada vez que agreguemos una migración debemos usar el comando:

`dotnet ef database update`
