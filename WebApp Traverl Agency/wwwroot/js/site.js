document.getElementById('search_input').addEventListener('keyup', cercaViaggio);

function cercaViaggio() {
    let cerca_input = document.getElementById('search_input').value;
    loadViaggi(cerca_input)
}