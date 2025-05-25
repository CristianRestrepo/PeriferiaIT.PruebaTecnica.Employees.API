<b>Proyecto Employees API</b>
<b>Detalles del proyecto</b>
<div>
  <p>El proyecto <b>PeriferiaIT.PruebaTecnica.Employees.API</b> es un Web API implementado con clean architecture y el patrón CQRS. Permite  creación de departamentos y empleados y ofrece los CRUDS necesarios para su administración.</p>
</div>
<div>
  <p>El proyecto implementa:</p>
</div>

  - <b>Repository Pattern</b>
  - <b>Unit Of Work Pattern</b>
  - <b>Autorización por JWT</b>
  - <b>Manejo de enumeradores</b>
  - <b>Clean Architecture</b>
  - <b>Patron CQRS para el manejo de operaciones de escritura y lectura en la capa de aplicación</b>
  - <b>MediaTR</b>


<b>Arquitectura del proyecto</b>

![PeriferiaIT-Employees API drawio](https://github.com/user-attachments/assets/97fccb47-53e3-4e64-9d88-402ad9a51e6c)

<b>Prerequisitos:</b>
- Docker
- Net 8.0
- Visual Studio 2022 o Visual Studio Code

<b>Pasos para levantar el ambiente:</b>

- Clonar repositorio.
- Desde un terminal acceder a la ruta donde se haya clonado el proyecto.
- Ejecutar el siguiente comando para levantar base de datos SqlServer:
  - <b>docker-compose up -d</b>
- Ejecutar el siguiente comando para ejecutar migraciones y crear base de datos:
  - <b>dotnet ef database update --project PeriferiaIT.PruebaTecnica.Employees.Infraestructure --startup-project PeriferiaIT.PruebaTecnica.Employees.API</b>
    - en caso de caso de que la consola indique que no se encuentra el comando, ejecutar:
      <b>dotnet tool install --global dotnet-ef --version 9.*</b>
- Ejecutar el siguiente comando para levantar la API
  <b>dotnet run --project PeriferiaIT.PruebaTecnica.Employees.API</b>
  - Si se desea acceder al swagger del proyecto ingresar al navegador a la URL: <b>[http://localhost:5158/swagger/index.html](http://localhost:5153/swagger/index.html)</b>
- Para autorizarse en el endpoint de Login y generar el token JWT utilizar <b>admin</b> como usuario y contraseña.

  <b>Ejemplo Request:</b>
  {
    "userName": "admin",
    "password": "admin"
  }  
