function registroautores(){
    var request = new Request('https://localhost:44348/api/values', {
        method: 'Post',
        headers: {  
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            ced: document.getElementById("ced").value,
            nom: document.getElementById("nom").value,
            nom2: document.getElementById("nom2").value,
            ap: document.getElementById("ap").value,
            ap2: document.getElementById("ap2").value,
            clave: document.getElementById("clave").value,
            email: document.getElementById("email").value,
            edad: parseInt(document.getElementById("edad").value),

        })
    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {

            alert(data);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function autenticarautor() {
    var ced = document.getElementById("ced").value;
    var clave = document.getElementById("clave").value;
    var request = new Request('https://localhost:44348/api/values/'+ced+"/"+clave+"/", {

        method: 'Get',

    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {
            if (data =="si"){
                localStorage.setItem("ced",ced);
                window.open("4.Autores.html")
            }
        })
        .catch(function (err) {
            console.error(err);
        });
}


function ingresoart() {
    var request = new Request('https://localhost:44348/api/valuescontroller1', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            ced: localStorage.getItem("ced"),
            titulo: document.getElementById("titulo_art").value,
            descripcion : document.getElementById("descripcion_art").value,
            contenido: document.getElementById("contenido_art").value,
            fecha: new Date().getFullYear()+"-"+parseInt( new Date().getMonth()+1)+"-"+new Date().getDate(),
        })
    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {

            alert(data);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function eliminarart(){
    ced =localStorage.getItem("ced");
    titulo= document.getElementById("titulo_art").value;
    var request = new Request('https://localhost:44348/api/valuescontroller1/'+ced+"/"+titulo+"/", {
        method: 'Delete',
        
    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {

            alert(data);
        })
        .catch(function (err) {
            console.error(err);
        });
}