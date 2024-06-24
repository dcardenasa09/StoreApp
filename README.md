# Aplicación Web (.Net 8 / Angular 16)
Esta Aplicación Web consta de dos peoryectos, uno en .Net 8 para el backend y Angular 16 para la parte del frontend, la base de datos es SQL Server

-------------------------------

> [!IMPORTANT]
> Puedes acceder con el siguiente usuario y contraseña para la gestion de los catalogos:
> - admin@example.com
> - Admin@123

## Ejecutar SQL con Docker Compose
Este repositorio contiene un archivo .yml que puede ser ejecutado utilizando Docker Compose.
Este contiene una imagen de SQL Serve para el manejo de base de datos.

> [!NOTE]
> Antes de empezar, asegúrate de tener instalados los siguientes requisitos:
> - Docker: [Instalación de Docker](https://docs.docker.com/get-docker/)
> - Docker Compose: [Instalación de Docker Compose](https://docs.docker.com/compose/install/)

### Ejecución

Sigue estos pasos para ejecutar SQL Server con Docker Compose y conectarlo con la aplicación:

1. **Clona el Repositorio:**
   git clone https://github.com/dcardenasa09/nombre-repositorio.git

2. **Accede a la carpeta raiz del proyecto:**
   cd nombre-repositorio

3. **Ejecuta Docker Compose:**
   docker-compose up -d

4. **Cambia la cadena de conexión en el Program.cs:**
   Cambia la cadena de conexión para hacer referencia a "DockerConnection"

## Notas, Tips y Alertas

>[!NOTE]
>
> - Creación de la Base de Datos:
>   Para la creacion de la base de datos se utilizaron los Migrates de EF Core.
>
> - Debug al API:
>   Se incluyen los archivos de Launch.json y tasks.json de .vscode para debugear el proyecto.
>
> - Seguridad de Contraseñas:
>   Las contraseñas y credenciales en este ejemplo son solo para propósitos de desarrollo.
>
> - Variables de Entorno:
>   Revisa y ajusta las variables de entorno en el archivo appsettings.json según sea necesario para tu entorno específico.
>
> - Contribuciones y Problemas:
>   Si deseas contribuir con mejoras o encuentras algún problema, por favor abre un issue o envía un pull request a través de GitHub.
