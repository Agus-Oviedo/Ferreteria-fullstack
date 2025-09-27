Proyecto FerreteriaStock — README

Sistema de gestión de stock para la ferretería Oxígeno Norte.
API REST en ASP.NET Core (.NET 8) + Frontend .NET MAUI + Blazor Hybrid.
Este README resume lo ya implementado en backend y frontend y explica cómo levantar el proyecto para subir a Git.

Contenido

Resumen del proyecto

Credenciales de prueba (demo)

Tecnologías

Estructura y endpoints principales (API)

Instrucciones para ejecutar la API (backend)

Instrucciones para ejecutar el Frontend (MAUI + Blazor)

Cómo agregar/sembrar los usuarios demo en la base de datos

Uso / ejemplos de requests

Notas de seguridad y buenas prácticas

Contacto

1. Resumen del proyecto

FerreteriaStock es una aplicación compuesta por:

Backend (FerreteriaAPI): API REST en ASP.NET Core que expone endpoints para autenticación y CRUD de usuarios/productos. Usa Entity Framework Core y SQL Server.

Frontend (FerreteriaStock): App híbrida móvil/escritorio con .NET MAUI + Blazor. Consume la API para login y gestión (productos/usuarios).

Estado actual:

API funcionando y probada con Swagger.

Frontend Blazor iniciado (Login, Productos, Usuarios, SesionUsuario, etc.).

Migraciones aplicadas y tablas creadas.

Faltan ajustes menores en rutas/layouts pero funcionalidad principal implementada.

2. Credenciales de prueba (demo)

Para pruebas locales / demo se crearon estos usuarios:

Administrador (Admin)

Email: guchi@gmail.com

Contraseña: guchi1234

Rol: Admin

Empleado

Email: user@gmail.com

Contraseña: user1234

Rol: Empleado

IMPORTANTE: Estas credenciales son de ejemplo. No las use en producción. Cambie contraseñas y aplique hashing/seguridad antes de desplegar.

3. Tecnologías

Backend: ASP.NET Core Web API (.NET 8)

ORM: Entity Framework Core (migrations)

Base de datos: SQL Server (local o hosting compatible)

Frontend: .NET MAUI + Blazor Hybrid

Autenticación simple via endpoint POST /api/login (email + clave)

Herramientas: Swagger (para probar endpoints), dotnet CLI

4. Estructura y endpoints principales
Backend (FerreteriaAPI) — carpetas clave

Controllers/

LoginController.cs → POST /api/login

UsuariosController.cs → CRUD /api/usuarios

ProductosController.cs → CRUD /api/productos (si está implementado)

Models/

Usuario.cs (Id, Nombre, Email, UsuarioAcceso, Clave, Rol)

Producto.cs (Id, Nombre, Descripcion, Precio, Stock)

LoginRequest.cs

Data/

AppDbContext.cs (DbSet<Usuario>, DbSet<Producto>)

Migrations/ → migraciones EF

Endpoints importantes

POST /api/login — cuerpo: { "email": "...", "clave": "..." }

GET /api/usuarios — lista de usuarios (restringido a admin)

POST /api/usuarios — crear usuario (admin)

GET /api/productos — lista de productos

POST /api/productos — crear producto (según permisos)
