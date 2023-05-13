const editarBtn = document.querySelector('.btn-outline-info');
const formulario3 = document.getElementById('formulario3');
const confimrarBtn = document.querySelector('#formulario3 input[type="submit"][value="Aceptar"]');
const volverBtn = document.querySelector('#formulario3 input[type="button"][value="Cancelar"]');



function ocultarFormulario3() {
    document.getElementById("formulario3").style.display = "none";
  }

editarBtn.addEventListener('click', () => {
  formulario3.style.display = 'block';
});


function mostrarformulario4() {
  document.getElementById("formulario4").style.display = "block";
  var Codigo = document.getElementById("codigo").value;
  var nombre = document.getElementById("nombre").value;
  var producto = document.getElementById("producto").value;
  var cantidad = document.getElementById("cantidad").value;
  var sede = document.getElementById("sede").value;

  // Mostrar el formulario 4 con los valores recuperados
  var formulario4 = document.getElementById("formulario4");
  formulario4.style.display = "block";
  formulario4.querySelector("#codigo").value = Codigo;
  formulario4.querySelector("#nombre").value = nombre;
  formulario4.querySelector("#producto").value = producto;
  formulario4.querySelector("#cantidad").value = cantidad;
  formulario4.querySelector("#fecha_ingreso").value = obtenerFechaActual();
  formulario4.querySelector("#sede").value = sede;
}

  function establecerFechaSalida() {
    var formulario4 = document.getElementById("formulario4");
    formulario4.querySelector("#fecha_salida").value = obtenerFechaActual();
  }

function obtenerFechaActual() {
  var fecha = new Date();
  var dia = fecha.getDate().toString().padStart(2, "0");
  var mes = (fecha.getMonth() + 1).toString().padStart(2, "0");
  var anio = fecha.getFullYear().toString();
  return anio + "-" + mes + "-" + dia;




}







