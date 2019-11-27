function MinhaFuncao2() {
    var x, text;
    x = document.getElementById("num").value;
    if (isNaN(x) || x < 1 || x > 10) {
        text = "Número inválido";
    }
    else {
        text = "Número " + x + " é válido";
    }
    document.getElementById("result").innerHTML = text;
}

function calcular(a,b) {
    var x = a * b;
    return x;
}