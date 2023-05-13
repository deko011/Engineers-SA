// Obtener el botón "Nuevo Producto"
var nuevoProductoBtn = document.getElementById("nuevo-producto");

// Obtener el formulario
var formulario = document.getElementById("formulario");

// Mostrar u ocultar el formulario al hacer clic en el botón "Nuevo Producto"
nuevoProductoBtn.addEventListener("click", function() {
  console.log("Hiciste clic en el botón 'Nuevo Producto'");
  if (formulario.style.display === "none") {
    formulario.style.display = "block";
  } else {
    formulario.style.display = "none";
  }
});