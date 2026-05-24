const btnPromise = document.getElementById("btn");
const txtNumero1 = document.getElementById("txtNumero1");
const txtNumero2 = document.getElementById("txtNumero2");
const txtResultado = document.getElementById("txtResultado");

btnPromise.addEventListener("click", function () {
  // let suma = 10 + parseInt(txtNumero.value);
  // alert(suma);
  // txtNumero.value = suma;
  let promise = new Promise(function (resolve, reject) {
    let n1 = parseFloat(txtNumero1.value);
    let n2 = parseFloat(txtNumero2.value);
    if(n2 == 0){
      reject("No se puede dividir entre cero");
    }
    else{
      let res = n1 / n2;
      //resolve(`Resultado: ${res}`);
      resolve("Resultado: " + res);
    }
  });
  promise.then(
    (result) => txtResultado.value = result,
    (error) => txtResultado.value = error,
  );
});
