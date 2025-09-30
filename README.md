# Prueba Técnica .NET 8 – API de Solicitudes de Viaje

## 📌 Descripción

Este proyecto es una **API REST** construida en **ASP.NET Core 8** con **Entity Framework Core** y **SQL Server**.
Permite la gestión de usuarios, autenticación con **JWT**, creación de solicitudes de viaje y recuperación de contraseñas.

## 🚀 Tecnologías usadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core 8
* SQL Server Express
* JWT (JSON Web Tokens)
* BCrypt (hashing de contraseñas)
* Swagger (documentación y pruebas)

## 📂 Estructura del proyecto

```
Prueba_Tecnica_net.sln
│
├── Prueba_Tecnica_net (API)        # Controladores y configuración
├── TravelRequests.Domain           # Entidades de dominio
├── TravelRequests.Infrastructure   # Persistencia (EF Core, DbContext)
```

## ⚙️ Configuración

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tuusuario/Prueba_Tecnica_net.git
   ```
2. Abre la solución en **Visual Studio 2022**.
3. Ajusta la cadena de conexión en `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TravelRequestsDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```
4. Aplica migraciones a la base de datos:

   ```powershell
   Update-Database -Project TravelRequests.Infrastructure -StartupProject Prueba_Tecnica_net
   ```
5. Ejecuta el proyecto con **F5**.

## 🔑 Endpoints principales

### Autenticación

* `POST /api/auth/register` → Registrar usuario
* `POST /api/auth/login` → Iniciar sesión (devuelve JWT)

### Solicitudes de viaje (requieren JWT)

* `GET /api/travelrequests` → Listar
* `POST /api/travelrequests` → Crear
* `PUT /api/travelrequests/{id}` → Actualizar
* `DELETE /api/travelrequests/{id}` → Eliminar

### Recuperación de contraseña

* `POST /api/passwordreset/request` → Generar código
* `POST /api/passwordreset/confirm` → Confirmar nueva contraseña

## 📖 Pruebas en Swagger

1. Registrar usuario
2. Hacer login y copiar token
3. Clic en **Authorize** en Swagger → pegar `Bearer <token>`
4. Probar CRUD de solicitudes de viaje
5. Probar recuperación de contraseña

👨‍💻 Desarrollado por

William Barrios Rivera

Estudiante de Ingeniería de Sistemas
---
