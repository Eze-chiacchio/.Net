// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ValidarNombre(nombresito) {
    var letras;
    letras = nombresito.length;
    if (letras < 30) {
        alert("Aprobado");
    } else {
        alert("Ese nombre es muy largo para un libro!");

    }

}