const $btnSignIn= document.querySelector('.btn-sign-in'),
      $btnSignUp = document.querySelector('.sign-up-btn'),  
      $signUp = document.querySelector('.sign-up'),
      $signIn  = document.querySelector('.sign-in'),
      $form = document.querySelector('.formulario');


const form = document.querySelector('.formulario');
const usuarioInput = form.querySelector('input[type="user"]');
const contraseñaInput = form.querySelector('input[type="password"]');
const btnSignIn = form.querySelector('.btn-sign-in');

form.addEventListener('submit', e => {
  e.preventDefault();

  const idUsuario = usuarioInput.value;
  const idContraseña = contraseñaInput.value;
  const idRol = 2; 
   

  fetch(`http://localhost:7071/api/V1.0/LoginCajero/${idUsuario}/${idContraseña}/${idRol}`, { 
    headers: {
      'Origin': '*'
    }
  })
  .then(response => {
    if (!response.ok) {
      throw new Error(response.statusText);
    }
    return response.json();
  })
  .then(data => {
    
    console.log(data);
    console.log("Redirigiendo a login.html");
    window.location.href = "http://127.0.0.1:5500/Html/cajero.html";
  })
  .catch(error => {
 
    console.error(error);
    alert('Usuario o contraseña incorrectos.');
  });
});