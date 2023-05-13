const sedeSelect = document.querySelector('#Inventario');
const eliminarBtn = document.querySelector('.btn-outline-danger');

const nuevoProductoBtn = document.getElementById('nuevo-producto');
const formulario = document.getElementById('formulario');
const guardarBtn = document.querySelector('#formulario input[type="submit"][value="Guardar"]');
const cancelarBtn = document.querySelector('#formulario input[type="button"][value="Cancelar"]');
const formulario2 = document.getElementById('formulario2');

const aceptarBtn = document.querySelector('#formulario2 input[type="submit"][value="Aceptar"]');
const salirBtn = document.querySelector('#formulario2 input[type="button"][value="Cancelar"]');

const codigoInput = document.querySelector('input[name="Codigo"]');






sedeSelect.addEventListener('change', () => {
  eliminarBtn.style.display = 'block';
  editarBtn.style.display = 'block';
  nuevoProductoBtn.style.display = 'block';
});

nuevoProductoBtn.addEventListener('click', () => {
  formulario.style.display = 'block';
});

guardarBtn.addEventListener('click', (event) => {
  event.preventDefault();
  
  const codigo = document.querySelector('#codigo').value;
  const nombre = document.querySelector('#nombre').value;
  const producto = document.querySelector('#producto').value;
  const cantidad = document.querySelector('#cantidad').value;
  const fechaIngreso = document.querySelector('#fecha_ingreso').value;
  const sedes = document.querySelector('#Sedes').value;

 

  const nuevoProducto = {
    codigo,
    nombre,
    producto,
    cantidad,
    fechaIngreso,
    sedes,
  };

  fetch('http://localhost:7071/api/V1.0/NuevoProducto', {
    method: 'POST',
    body: JSON.stringify(nuevoProducto),
    headers: {
      'Content-Type': 'application/json'
    }
  })
  .then(response => {
    if (response.ok) {
      alert('Producto nuevo ingresado');
      formulario.style.display = 'none';
    } else {
      throw new Error('No se completo el registro de nuevo producto');
    }
  })
  .catch(error => {
    alert(error.message);
  });
});

cancelarBtn.addEventListener('click', () => {
  formulario.style.display = 'none';
});


function ocultarFormulario2() {
  document.getElementById("formulario2").style.display = "none";
}


eliminarBtn.addEventListener('click', () => {
  formulario2.style.display = 'block';
});



eliminarBtn.addEventListener('click', () => {
  formulario2.style.display = 'block';
});





aceptarBtn.addEventListener('click', (event) => {
  event.preventDefault();
  
  const codigo = codigoInput.value;

  console.log(codigo);
  
  fetch(`http://localhost:7071/api/V1.0/EliminarRegistroInventario/${codigo}`, {
  method: 'DELETE',
  headers: {
    'Content-Type': 'application/json'
  }
})
  .then(response => {
    if (response.ok) {
      alert('Producto eliminado con éxito');
      formulario2.style.display = 'none';
    } else {
      throw new Error('No se pudo eliminar el registro');
    }
  })
  .catch(error => {
    alert(error.message);
  });
});

salirBtn.addEventListener('click', () => {
  formulario2.style.display = 'none';
});

























