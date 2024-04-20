##Datos Importantes
  - El API service y base de datos estan desplegados usando servicios de Azure.
  - Se utilizo una base de datos postgres y dentro de la carpeta /SmartTalentTechnicalTest puedes encontrar una imagen llamada diagramUML.jpg en esta muestro el esquema para la base de datos utilizada.
  - Cualquier detalle adicional estoy totalmente a disposición.


## Explicación
- Para solucionar la prueba utilice DDD y CQRS como esquemas de arquitectura, estos con el objetivo de garantizar un orden y una legibilidad del codigo. Para esta arquitectura defini en el dominio mis 3 entidades
  y estableci sus respectivos repositorios y comunicaciones con la capa de aplicacion debido a que al ser una solucion orientada al dominio todo el codigo gira en torno a las 3 entidades definidas.
- Para el despliegue en azure del api use el servicio conexion de azure y github donde se actualiza el despliegue en azure de forma automatizada al subir cambios en la rama master.

## Funcionamiento
  - Para ver el api desplegado utiliza el siguiente enlace: https://pruebatecnicaapi.azurewebsites.net/swagger/index.html
  - El codigo esta conectado al servicio de bases de datos de azure por lo que no necesitas tener nada en local para interactuar con el API.
  - Existen 2 productos y 2 usuarios por defecto, puedes crear uno nuevo o ver los existentes.
  - Es necesario loguearse con alguno de los usuarios para que funcione la API, el login crea una cookie en el navegadorcon la informacion del usuario logueado por lo que cada endpoint valida quien hace la peticion,
    Ademas de que si usas el usuario de admin o de user, podrar usar uno o otros endpoint, aqui se valida que los usuarios normales no puedan interactuar con endpoints administrativos y esto se determino con la columna type de los usuarios.
  - Debido a que la base de datos por defecto esta en la nube y no podras ver a los usuarios para usar sus credenciales y loguearte adjunto aqui el usuario y contraseña de los 2 usuarios:
    - usuario User:
        - correo: aaa
        - contraseña: aaa
    - usuario Admin:
        - correo: info@smartalentit.com
        - contraseña: aaa
  - Igualmente si deseas validar la base de datos, puedo brindar los datos de conexion si son requeridos.
  - Al ser una API se deben llenar manualmente los endpoints, ademas de que al crear una nueva Order se envia un correo conla informacion del pedido, **NOTA** El correo al que se hace el envio es el del usuario, por lo que recomiendo usar el user Admin,
    ya que es un correo existente.

** Gracias por la oportunidad **


