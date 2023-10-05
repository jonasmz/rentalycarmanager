# Avance del Proyecto

Este documento proporciona una descripción del progreso actual del proyecto y las tareas realizadas hasta ahora.

## Contexto de la Base de Datos

Hemos creado el contexto de la base de datos utilizando el ORM Microsoft Entity Framework Core. Este contexto servirá como la interfaz principal para interactuar con la base de datos y realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en nuestras entidades.

## Entidades de Usuarios y Roles

Hemos definido las entidades de Usuarios y Roles que serán fundamentales para la gestión de la autenticación y autorización en la aplicación. Estas entidades se implementarán utilizando el framework Microsoft Identity, lo que nos permitirá administrar de manera eficiente la autenticación de usuarios y sus roles en la aplicación.

#### Carcateristicas implementadas: 
	 - Implementación de la lógica de registro y inicio de sesión de usuarios.

## Implementación de Tokens JWT

Para mejorar la seguridad y la autenticación en la aplicación, hemos implementado la generación, entrega y validación de tokens JWT (JSON Web Tokens). Estos tokens se generarán utilizando la especificación Bearer y se utilizarán para autenticar y autorizar a los usuarios en las solicitudes a nuestros servicios web. La implementación de tokens JWT nos permite lograr un sistema de autenticación robusto y seguro.

## Próximos Pasos

Nuestro proyecto está avanzando según lo planeado, y los siguientes pasos incluyen:

- Configuración de políticas de autorización basadas en roles.
- Desarrollo de controladores y servicios relacionados con la gestión de usuarios y roles.
- Integración de la capa de presentación de la aplicación (interfaz de usuario).

Este README se actualizará periódicamente para reflejar el progreso del proyecto y proporcionar información adicional sobre su desarrollo. Si tienes alguna pregunta o comentario, no dudes en ponerte en contacto con el equipo de desarrollo.
