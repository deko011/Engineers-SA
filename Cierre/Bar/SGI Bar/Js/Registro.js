const contenido = document.getElementById("contenido");
const usuarios = document.getElementById("usuarios");
const registroForm = document.getElementById('registro-form');
const cedulaInput = document.getElementById('cedula');
const passwordInput = document.getElementById('password');
const backButton = document.querySelector('.back-button');
const usuarioInput = document.getElementById('usuario');

usuarioInput.placeholder = `Recuerde que su usuario es su cedula: ${cedulaInput.value}`;
passwordInput.placeholder = `Recuerde que su contraseña es su cedula: ${cedulaInput.value}`;

usuarios.addEventListener("click", function() {
    registroForm.style.display = 'block';
    document.getElementById('nombre').focus();
});

document.querySelectorAll('input, select').forEach(field => {
    field.addEventListener('input', function() {
        this.classList.toggle('filled', this.value.trim() !== '');
    });
});

function establecerUsuarioYContraseña() {
    const cedula = cedulaInput.value;
    usuarioInput.value = cedula;
    passwordInput.value = cedula;
}

cedulaInput.addEventListener('input', establecerUsuarioYContraseña);
establecerUsuarioYContraseña();

usuarioInput.readOnly = true;
passwordInput.readOnly = true;

registroForm.addEventListener('submit', (event) => {
    event.preventDefault();

    const form = document.querySelector('form');
    const nombreInput = document.querySelector('#nombre');
    const cedulaInput = document.querySelector('#cedula');
    const usuarioInput = document.querySelector('#usuario');
    const passwordInput = document.querySelector('#password');
    const rolSelect = document.querySelector('#rol');

    const nombre = nombreInput.value;
    const cedula = cedulaInput.value;
    const usuario = usuarioInput.value;
    const password = passwordInput.value;
    const rol = document.getElementById("rol").value;
   
    console.log('Valor de rolSelect:', rolSelect.value);
    console.log('Valor de rol:', rol);

    const usuarioNuevo = {
        nombre: nombre,
        cedula: cedula,
        usuario: cedula, // establecer el valor de usuario como cedula
        contraseña: cedula, // establecer el valor de contraseña como cedula
        rol: rol
    };

    fetch('http://localhost:7071/api/V1.0/RegistroUsuarioNuevo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuarioNuevo)
    })
    .then(response => {
        if (response.ok) {
           
            alert('Registro exitoso');
            form.reset(); 
        } else {
            
            alert('Error al registrar usuario');
        }
    })
    .catch(error => {
       
        alert('Error de conexión con la API');
        console.error(error);
    });
});