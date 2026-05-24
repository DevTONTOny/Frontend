const nombres = ["Antonio", "Diego", "José", "Angel", "Octavio", "Geovanni"];

const data = {
    labels: nombres,
    datasets: [
        {
            label: "Miguel",
            data: [100, 20, 10, 50, 60, 80],
            backgroundColor: ['rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)'],
            borderWidth: 1,
        },

        {
            label: "Marco",
            data: [10, 30, 40, 50, 90, 100],
            backgroundColor: ['rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)'],
            borderWidth: 1,
        }
    ]
};

const config = {
    type: 'bar',
    data: data,
    options: {responsive: true,}
};

const ctx = document.getElementById('grafica').getContext('2d');
const graficaSellos = new Chart(ctx, config);