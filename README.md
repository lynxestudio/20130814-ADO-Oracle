# ADO.NET Helper para Oracle

<p align="Justify">
Hace bastante tiempo que hice unas clases de ADO.NET para Oracle (un tipo helper de manera elemental). quizá no es la manera más optima de acceder a una base de datos, pero al menos en ambientes restringidos en donde no es posible instalar frameworks u otro proveedor de ADO.NET para Oracle que no sea el que viene predeterminado por .NET.</p>
<P>
Las clases que componen el ADO Helper para Oracle son las siguientes:
<ul>
<li><b>OracleDataBase:</b> Clase que maneja la conexion.</li>
<li><b>OracleDataBaseCommand:</b> Clase que maneja los comandos que se enviaran a la base de datos.</li>
<li><b>EmployeeDac:</b> Clase que utiliza las clases auxiliares para guardar un objeto, en este caso se utiliza para una entidad <i>Employee</i>.</li>
</ul>
</p>
<p>
Para probar este ADO Helper escribe un formario que guarda un registro en una base de datos Oracle Express XE como se ve en loa siguientes screenshots.
<div><b>Fig 1. Programa que crea, consulta un empleado en la base de datos.</b></div><br>
<div>
<IMG src="images/oraAdo1.png">
</div>
<div><b>Fig 2. Creando un empleado en la base de datos.</b></div><br>
<div>
<IMG src="images/oraAdo2.png">
</div>
<div><b>Fig 3. Consultando los empleados en la base de datos.</b></div><br>
<div>
<IMG src="images/oraAdo3.png">
</div>
</p>

