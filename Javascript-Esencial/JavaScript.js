//Esto para habilitar reglas para escribir codigo
'use strict';

//numero aleatorio
function generarNumeroAleatorio (min, max) {
    return Math.floor(Math.random()*(max - min + 1)) + min;
}

let ran = generarNumeroAleatorio(1,10);
alert(ran);
//////////////////////////////////////////////
//Condicion del clima
let x = 10;
let temp = 25;

if (temp > 30){
    console.log("Es un dia muy caluroso");
} else if(temp >= 20){
    console.log("Es un dia muy placentero");
}else{
    console.log("Es un dia muy frio");
}
 