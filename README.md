# **PTEI.Backend.Exercise2**
## WEB API para operaciones de busqueda de clientes en una base de datos SQLServer
## Requisitos

[.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

[SQLServer](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)

## Empezar

Empiece clonando el repositorio

```bash
git clone https://github.com/jesusaraujo06/PTEI.Backend.Exercise2.git
```

Diríjase a la ruta donde clonó el repositorio y abra la solución con Visual Studio o Visual Studio Code.

```bash
cd your_path
```

Diríjase al proyecto ‘`CustomerSearch.API`’, abra el archivo ‘`appsettings.json`’ y modifique la propiedad ‘`ConnectionStrings`' según la conexión a su base de datos SQLServer.

```json
"ConnectionStrings": {
    "CustomerConnection": "Server=YourSERVERSQLServer;Database=Exercise2Db;User Id=root;Password=root123; Integrated Security=True; TrustServerCertificate=True;"
  }
```

### Creación de la base de datos

Crear la base de datos con el siguiente query:
```sql
-- Crear la base de datos Exercise2Db
CREATE DATABASE Exercise2Db;

USE Exercise2Db;

CREATE TABLE customers
(
    CustomerId INT PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(100),
    City NVARCHAR(50)
);

-- Insertar datos ficticios en la tabla customers
INSERT INTO customers (CustomerId, FirstName, LastName, Email, PhoneNumber, Address, City)
VALUES
    (1, N'Juan', N'Gómez', N'juan@gmail.com', N'555-123-4567', N'Calle 123', N'Bogotá'),
    (2, N'María', N'López', N'maria@hotmail.com', N'555-987-6543', N'Avenida Principal', N'Medellín'),
    (3, N'Carlos', N'Ruíz', N'carlos@yahoo.com', N'555-555-5555', N'Calle Central', N'Cali'),
    (4, N'Ana', N'Rodríguez', N'ana@gmail.com', N'555-111-2222', N'Av. Libertad', N'Barranquilla'),
    (5, N'Luis', N'Fernández', N'luis@hotmail.com', N'555-333-4444', N'Calle 45', N'Cartagena'),
    (6, N'Sofía', N'Martínez', N'sofia@yahoo.com', N'555-555-1234', N'Plaza Mayor', N'Cali'),
    (7, N'Miguel', N'Pérez', N'miguel@gmail.com', N'555-999-8888', N'Carrera 67', N'Medellín'),
    (8, N'Laura', N'González', N'laura@hotmail.com', N'555-777-6666', N'Calle 56', N'Cúcuta'),
    (9, N'David', N'Díaz', N'david@yahoo.com', N'555-444-3333', N'Av. Bolívar', N'Bogotá'),
    (10, N'Isabella', N'Rojas', N'isabella@gmail.com', N'555-666-5555', N'Carrera 32', N'Pereira'),
    (11, N'Santiago', N'Hernández', N'santiago@hotmail.com', N'555-222-3333', N'Calle 89', N'Medellín'),
    (12, N'Valentina', N'Martínez', N'valentina@yahoo.com', N'555-777-9999', N'Carrera 25', N'Calí'),
    (13, N'Diego', N'García', N'diego@gmail.com', N'555-111-5555', N'Plaza Mayor', N'Cúcuta'),
    (14, N'Camila', N'López', N'camila@hotmail.com', N'555-333-1111', N'Calle 75', N'Medellín'),
    (15, N'Mateo', N'Fernández', N'mateo@yahoo.com', N'555-444-8888', N'Carrera 60', N'Bogotá'),
    (16, N'Martina', N'Ruíz', N'martina@gmail.com', N'555-666-2222', N'Avenida 6', N'Cali'),
    (17, N'Lucas', N'Rodríguez', N'lucas@hotmail.com', N'555-555-4444', N'Calle 22', N'Cartagena'),
    (18, N'Sara', N'Pérez', N'sara@yahoo.com', N'555-333-6666', N'Av. Libertad', N'Barranquilla'),
    (19, N'Daniel', N'Martínez', N'daniel@gmail.com', N'555-777-5555', N'Carrera 40', N'Pereira'),
    (20, N'Valeria', N'González', N'valeria@hotmail.com', N'555-999-3333', N'Calle 78', N'Medellín');
```

Al ejecutar el query, en este punto ya se habrá creado la base de datos ‘Exercise2Db’ en su SQLServer.

Eso es todo, ya podemos ejecutar el proyecto `CustomerSearch.API`

## Demostración:

![image](https://github.com/jesusaraujo06/PTEI.Backend.Exercise2/assets/72844628/3b89d11b-e137-42f9-b369-43367b64231a)

La WEB API cuenta con una serie de endpoints para hacer una busqueda efectiva de clientes, incluido un endpoint: `GetCustomersByFieldsPartial`, para usar en los campos de busqueda en el frontend.

### Prueba del endpoint: `GetCustomersByFieldsPartial`
Descripción del endpoint: Obtener un listado de clientes teniendo en cuenta uno o más campos de la tabla y un termino de busqueda

Request URL:

```bash
https://localhost:7294/Customer/GetCustomersByFieldsPartial?fieldNames=LastName&fieldNames=FirstName&searchTerm=Da
```

Response Body:

```json
[
  {
    "customerId": 9,
    "firstName": "David",
    "lastName": "Díaz",
    "email": "david@yahoo.com",
    "phoneNumber": "555-444-3333",
    "address": "Av. Bolívar",
    "city": "Bogotá"
  },
  {
    "customerId": 19,
    "firstName": "Daniel",
    "lastName": "Martínez",
    "email": "daniel@gmail.com",
    "phoneNumber": "555-777-5555",
    "address": "Carrera 40",
    "city": "Pereira"
  }
]
```

### Consideraciones
La solución esta creada de tal forma que:
- Se abstrae la logica de negocio / empresarial en un proyecto Domain
- Cada servicio debe implementar su interfaz
- Se utiliza la inyección de dependencias
- Se utiliza Dapper como MicroORM para el acceso a los datos

## **Descripción de la prueba técnica**
En este ejercicio, se te pide que desarrolles un controlador en una Web API .NET Core C# que
implemente el principio SOLID de Inversión de Dependencias. El controlador debe permitir a los
usuarios realizar operaciones de búsqueda en una tabla de clientes en una base de datos SQL
Server.

###Requisitos
- La Web API debe implementar una clase Service que sea responsable de las operaciones de
búsqueda en la tabla de clientes.
- La Web API debe implementar un controlador que se encargue de manejar las solicitudes de los
usuarios para realizar operaciones de búsqueda en la tabla de clientes.
- El controlador debe estar diseñado de manera que la lógica de negocio (búsqueda en la tabla de
clientes) se encapsule en la clase Service.
- La clase Service debe implementar una interfaz que permita la inversión de dependencias.
- El controlador debe ser capaz de recibir solicitudes en formato JSON y devolver respuestas en
formato JSON.

###Entregables
- El código fuente de la Web API en un repositorio de Git.
- Un archivo README que explique cómo se puede ejecutar la Web API y cualquier otra información
relevante.
