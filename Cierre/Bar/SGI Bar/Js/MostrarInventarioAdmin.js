// Obtener la referencia al select
var selectSede = document.getElementById("Inventario");

// Obtener la referencia a la tabla
var tabla = document.getElementById("Tabla-Inventario");
if (tabla) {
  tabla.innerHTML = "";
  // Resto del código aquí
} else {
  console.error("La tabla no se ha encontrado en la página.");
}

// Agregar un evento change al select
selectSede.addEventListener("change", function() {
  // Obtener el valor seleccionado del select
  var sedeSeleccionada = selectSede.value;

  // Hacer la petición a la API
  fetch(`http://localhost:7071/api/V1.0/InventarioAdmin/${sedeSeleccionada}`)
    .then(response => response.json())
    .then(data => {
      console.log(data);
      tabla.innerHTML = "";

      // Crear la cabecera de la tabla
      var thead = document.createElement("thead");
      var trHead = document.createElement("tr");
      var thCodigo = document.createElement("th");
      var thNombre = document.createElement("th");
      var thProducto = document.createElement("th");
      var thCantidad = document.createElement("th");
      var thFechaIngreso = document.createElement("th");
      var thFechaSalida = document.createElement("th");

      thCodigo.textContent = "Código";
      thNombre.textContent = "Nombre";
      thProducto.textContent = "Producto";
      thCantidad.textContent = "Cantidad";
      thFechaIngreso.textContent = "Fecha Ingreso";
      thFechaSalida.textContent = "Fecha Salida";

      trHead.appendChild(thCodigo);
      trHead.appendChild(thNombre);
      trHead.appendChild(thProducto);
      trHead.appendChild(thCantidad);
      trHead.appendChild(thFechaIngreso);
      trHead.appendChild(thFechaSalida);

      thead.appendChild(trHead);
      tabla.appendChild(thead);

      // Crear las filas de la tabla
      var tbody = document.createElement("tbody");

      data.forEach(producto => {
        console.log(producto);

        var tr = document.createElement("tr");
        var tdCodigo = document.createElement("td");
        var tdNombre = document.createElement("td");
        var tdProducto = document.createElement("td");
        var tdCantidad = document.createElement("td");
        var tdFechaIngreso = document.createElement("td");
        var tdFechaSalida = document.createElement("td");

        tdCodigo.textContent = producto.codigo;
        tdNombre.textContent = producto.nombre;
        tdProducto.textContent = producto.producto;
        tdCantidad.textContent = producto.cantidad;
        tdFechaIngreso.textContent = producto.fecha_ingreso;
        tdFechaSalida.textContent = producto.fecha_salida;

        tr.appendChild(tdCodigo);
        tr.appendChild(tdNombre);
        tr.appendChild(tdProducto);
        tr.appendChild(tdCantidad);
        tr.appendChild(tdFechaIngreso);
        tr.appendChild(tdFechaSalida);

        tbody.appendChild(tr);
      });

      tabla.appendChild(tbody);
    })
    .catch(error => console.error(error));
});

