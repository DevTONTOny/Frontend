const txtAnio = document.getElementById("anio");
const txtInscritos = document.getElementById("inscritos");
const ctx = document.getElementById('estadisticas').getContext('2d');
const btn = document.getElementById("btnGraficar");
const body = document.getElementById("body");
const selectCarrera = document.getElementById("selectCarrera");
const btnAgregarCarrera = document.getElementById("btnAgregarCarrera");
const txtCarrera = document.getElementById("carrera");

let inscritos = [];
let carreras = [];

btnAgregarCarrera.addEventListener("click", () => {
    const carrera = txtCarrera.value;
    if (carrera !== "") {
        carreras.push(carrera);
        const option = document.createElement("option");
        option.value = carrera;
        option.text = carrera;
        selectCarrera.appendChild(option);
        txtCarrera.value = "";
    }
    console.log(carreras);
});


const config = {
    type: 'bar',
    data: {
        labels: inscritos.map(inscritos => inscritos.carrera),
        datasets: [
            {
                label: 'Inscritos',
                data: inscritos.map(inscrito => inscrito.total),
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }
        ]
    },
    options: { responsive: true, }
};
const myChart = new Chart(ctx, config);
btn.addEventListener("click", () => {
    const carrera = selectCarrera.value;
    const cantidad = parseInt(txtInscritos.value);

    let existente = inscritos.find(item => item.carrera == carrera);

    if (existente) {
        existente.total += cantidad;

        const index = myChart.data.labels.indexOf(carrera);
        
        myChart.data.datasets[0].data[index] = existente.total;
        console.log(index);

        console.log("Carrera existente, agregados:", cantidad);
    } else {
        inscritos.push({ carrera: carrera, total: cantidad });
        myChart.data.labels.push(carrera);
        myChart.data.datasets[0].data.push(cantidad);

        console.log("Carrera nueva agregada:", carrera);
    }

    myChart.update();
});


// async function obtenerEstadisticas() {
//     const resp = await fetch("http://localhost:5044/api/estadisticas");
//     inscritos = await resp.json();
//     for (let i = 0; i < inscritos.length; i++) {
//         inscritos[i].anio = parseInt(inscritos[i].anio);
//         inscritos[i].total = parseInt(inscritos[i].total);
//         myChart.data.labels.push(inscritos[i].anio);
//         myChart.data.datasets[0].data.push(inscritos[i].total);
//     }
//     console.log(inscritos);
//     myChart.update();
// }

// body.onload = obtenerEstadisticas();

