const ctx = document.getElementById('estadisticas').getContext('2d');
const body = document.getElementById('body');
const btnAgregarPersona = document.getElementById('btnAgregar');
const lblhombres = document.getElementById("hombres");
const lblmujeres = document.getElementById("mujeres");
const btnNav = document.getElementById("btnNav");
const btnReset = document.getElementById("btnReset");



let hombres = [];
let mujeres = [];
let personas = [];

const config = {
    type: 'bar',
    data: {
        labels: personas.map(personas => personas.results[0].gender),
        datasets: [
            {
                label: 'Personas',
                data: personas.map(personas => personas.length),
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }
        ]
    },
    options: { responsive: true, }
};

const myChart = new Chart(ctx, config);
body.onload = myChart.data.labels.push("Hombres");
body.onload = myChart.data.labels.push("Mujeres");


async function obtenerPersona() {
    
    const resp = await fetch("https://randomuser.me/api/");

    persona = await resp.json();
    personas.push(persona);
    const img = document.createElement("img");
    const contenedor = document.createElement("div");
    const container = document.createElement("div");
    
    const alerta = document.createElement("div");
    const nombre = document.createElement("h5");
    const textAlerta = document.createElement("h5");
    nombre.className = "card-title";
    nombre.textContent = persona.results[0].name.first;
    contenedor.className = "card";
    contenedor.style.width = "18rem";
    contenedor.align = "center";
    textAlerta.textContent = "Usuario obtenido existosamente";
    container.className = "container d-flex gap-3 justify-content-center";
    alerta.className = "alert-primary position-fixed top-0 end-0 mt-3 me-3 fade show";
    alerta.role = "alert";
    if (persona.results[0].gender == "male") {
        hombres.push(persona);
        console.log(persona.results[0].gender);
        myChart.data.datasets[0].data[0] = hombres.length;
        lblhombres.textContent = "total de hombres: " + hombres.length;

    } else {
        mujeres.push(persona);
        console.log(persona.results[0].gender);
        myChart.data.datasets[0].data[1] = mujeres.length;
        lblmujeres.textContent = "total de mujeres: " + mujeres.length;
    }
    img.src = persona.results[0].picture.large;
    img.style.borderRadius = "50%";
    img.style.margin = "1rem auto 0.5rem auto";
    img.style.display = "block";
    container.appendChild(contenedor);
    contenedor.appendChild(img);
    contenedor.appendChild(nombre);
    alerta.appendChild(contenedor);
    body.appendChild(container);
    body.appendChild(alerta);
    
    setTimeout(() => {
                alerta.remove();
            }, 3000);
    console.log(personas.length);
    myChart.update();
}
body.onload = obtenerPersona();
body.onload = myChart.update();
btnAgregarPersona.addEventListener("click", () => {
    obtenerPersona();
});

btnNav.addEventListener("click", () => {
    obtenerPersona();
});

btnReset.addEventListener("click", () => {
    location.reload();
});