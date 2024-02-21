# ADO.NET Helper para Oracle

<p align="Justify">
Hace bastante tiempo que hice unas clases de ADO.NET para Oracle (un tipo helper de manera elemental). quizá no es la manera más optima de acceder a una base de datos, pero al menos en ambientes restringidos en donde no es posible instalar frameworks u otro proveedor de ADO.NET para Oracle que no sea el que viene predeterminado por .NET.</p>
<p>Aquí esta la clase para manejar la conexión, se llama <b>OracleDataBase</b></p>
<!-- Oracledatabase Class -->
<div><b>Fig 1. Clase para manejar la conexion a la base de datos.</b></div><br>
<div>
<IMG src="picture_library/adohelperoracle/oracledatabase.png">
</div><br>
<div>Utilizo otra clase llamada <i>OracleDataBaseCommand</i> para auxiliarme con los comandos.</div>
<div><b>Fig 2. Clase auxiliar para ejecutar los comandos en la base de datos.</b></div><br>
<div>
<IMG src="picture_library/adohelperoracle/oracledatabasecommand.png">
</div><br>
<p>Su utilización dentro de una clase que sirva para persistir o extraer datos sería de la siguiente manera.</p>
<div><b>Fig 3. Clase que utiliza las clases auxiliares para guardar un objeto.</b></div><br>
<div>
<IMG src="picture_library/adohelperoracle/customermanager.png">
</div><br>
<div><b>Fig 4. Clase principal que crea, actualiza y consulta un cliente en la base de datos.</b></div><br>
<div>
<IMG src="picture_library/adohelperoracle/program.png">
</div>
<br>
