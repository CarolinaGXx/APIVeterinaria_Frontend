# Frontend – Proyecto Veterinaria
**Integración Frontend y Backend – Blazor + FastAPI**

Este es el frontend del Proyecto Veterinaria, desarrollado con Blazor WebAssembly, encargado de consumir la API creada en Python con FastAPI.
El sistema permite gestionar información veterinaria a través de operaciones CRUD completas, junto con un sistema de login con autenticación JWT, y persistencia del usuario mediante localStorage.

**Tecnologías utilizadas**

- Blazor WebAssembly (.NET)
- C#
- HTML / CSS
- JS Interop
- FastAPI (consumo de API)
- JWT (autenticación)
- localStorage

**Características principales**

Este frontend permite:

**Autenticación**

- Login con correo y contraseña.
- Obtención de token JWT desde el backend.
- Guardado seguro del token y datos del usuario en localStorage.
- Redirección basada en autenticación.

**Módulos CRUD**

El sistema interactúa con la API para:

- Crear registros
- Consultar registros
- Editar registros
- Eliminar registros
- Listar todos los registros
- Buscar o filtrar elementos

**Integración absoluta con FastAPI**

Todas las acciones del usuario se reflejan directamente en el backend.
Pueden verse en tiempo real usando la pestaña Network del navegador.

**Instalación y ejecución**
```
1️. Clonar el repositorio
git clone https://github.com/CarolinaGXx/APIVeterinaria_Frontend

2️. Abrir el proyecto
Puedes abrirlo desde Visual Studio, VSCode o cualquier IDE compatible con .NET.

3️. Ejecutar el frontend
dotnet watch run

La aplicación correrá en:
https://localhost:7231/ 
o
http://localhost:5083/
```
**Conexión con el backend**

El proyecto se conecta con la API desarrollada en FastAPI.
La URL del backend debe configurarse en el archivo:
```
wwwroot/appsettings.json

Ejemplo:

{
  "ApiUrl": "http://localhost:8000"
}
```
**Pruebas y demostración**

En el video de entrega mostramos:

- Consumo de endpoints en la pestaña Network
- Procesos de autenticación
- CRUD completo funcionando
- Manejo correcto del token JWT
- Integración entre Blazor y FastAPI

Link YouTube: https://youtu.be/_4A4I863dSs

**Integrantes**

Dahyana Carolina Gonzalez

Santiago Gonzalez

**Repositorios**

Frontend

https://github.com/CarolinaGXx/APIVeterinaria_Frontend

Backend FastAPI

https://github.com/CarolinaGXx/APIVeterinaria_Parcial1



