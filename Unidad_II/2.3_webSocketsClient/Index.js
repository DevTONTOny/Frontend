const conexion = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5009/MapacheWebSocketServer",{withcredentials: false})
    .build();

conexion.start().then(function () {
    console.log("Conectado");
}).catch((e) => {
    console.log("Error de conexion");
});
    