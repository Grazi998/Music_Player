'use strict';

const idPrefixes = {
    getForArrayPrint() { return 'array_print#' },
    getForTableContainer() { return 'table_container#' }
};

function isEmptyObject(obj) {
    return Object.entries(obj).length === 0 && obj.constructor === Object;
}

/// provjerava je li tip podatka broj
function isNumber(arg) {
    return typeof (arg) === 'number';
}

/// provjerava je li tip podatka objekt
function isObject(arg) {
    return typeof (arg) === 'object';
}

/// provjerava je li tip podatka niz
function isArray(arg) {
    return Array.isArray(arg);
}

/// provjerava je li tip podatka funkcija
function isFunction(arg) {
    return typeof (arg) === 'function';
}

/// provjerava je li tip podatka string
function isString(arg) {
    return typeof arg === 'string' || arg instanceof String;
}

/// funkcija vraća regularni izraz za email
function emailRegex() {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
}

/// dobavi slucajan cijeli broj u zadanom rasponu [a, b] 
function slucajniBroj(a, b) {
    return Math.floor(Math.random() * (b - a + 1) + a);
}
/// stvara niz slucajnih cijelih brojeva duljine n u rasponu [a, b]
function stvoriNizSlucajnihBrojeva(n, a = 0, b = 10) {
    return [...new Array(n)].map(_ => slucajniBroj(a, b));
}

/// provjerava je li znak ch jednak jednom od:
/// - prazno mjesto
/// - tab
/// - novi red
/// - carriage return
/// - vertiakalni tab
function jedanOdPraznihZnakova(ch) {
    return ' \t\n\r\v'.indexOf(ch) > -1;
}

/// provjerava sadrži li string jedan od posebnih znakova (bez razmaka)
function jedanOdPosebnihZnakova(ch) {
    const reg = /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
    return reg.test(ch);
}

/// pretvara tekst u niz: "Hello" -> ["H", "e", "l", "l", "o"]
function tekstUNiz(tekst) {
    return [...tekst];
}

/// pretvora niz u tekst: ["H", "e", "l", "l", "o"] -> "Hello" ili [1, 2, 3, 4, 5] -> "12345"
function nizUTekst(niz) {
    return niz.reduce((x, y) => x.toString() + y);
}

/// vraća prvih n elemenata teksta
function prvihNTeksta(tekst, n) {
    return tekst.substring(0, n);
}

/// funkcija izbacuje posljdnjih n elemenata iz teksta
function tekstBezZadnjihN(tekst, n) {
    return prvihNTeksta(tekst, tekst.length - n);
}

/// vraća prvih n elemenata niza
function prvihNNiza(niz, n) {
    return niz.slice(0, n);
}

/// vraća obrnuti tekst
function obrniTekst(tekst) {
    return nizUTekst([...tekst].reverse());
}

/// pomocna funkcija za stvaranje html elemenata sa jedinstvenim id-em
function getNextId(idPrefix) {
    return document.querySelectorAll('*[id^="' + idPrefix + '"]').length + 1;
}

/// Mijenja vidljivost HTML elementa postavljajući css display svojstvo
/// Drugi argument nije obavezan, ali ako se prosljedi, display se postavlja na 
/// prosljeđenu vrijednost ako se element otkriva
function promijeniVidljivost(element, value) {
    let displayValue = value || 'block';
    element.style.display = element.style.display === 'none' ? displayValue : 'none';
}

/// Mijenja vidljivost HTML elementa s prosljeđenim IDom postavljajući css display svojstvo
/// Drugi argument nije obavezan, ali ako se prosljedi, display se postavlja na 
/// prosljeđenu vrijednost ako se element otkriva
function promijeniVidljivostPoIdu(id, value) {
    var element = document.getElementById(id);
    if (element === null) return;
    promijeniVidljivost(element, value);
}

/// Broj unutar raspona [a, b]
function uRasponu(a, b, broj) {
    return broj >= a && broj <= b;
}

/// Iz niza HTML elemenata izvlači innerHTML ili value i pretvara ga u cijeli broj (ako je moguće)
/// Prvi argument: Niz html elemenata tipa NodeList (rezultat document.getElementsByName funkcije)
/// Drugi argument: koristiti innerHTML, ako je false, koristit će se value
function pretvoriNizHtmlElemenataUNizVrijednosti(htmlNodes, innerHTML = true) {
    let values = [];

    for (var i = 0; i < htmlNodes.length; i++) {
        let node = htmlNodes[i];
        let value = innerHTML ? node.innerHTML : node.value;
        values.push(value);
    }

    return values
}

/// Pretvara niz vrijednosti u cijeli broj
/// npr: ["2", "3", "4"] -> [2, 3, 4]
function mapToInt(niz) {
    return niz.map(x => parseInt(x))
}

/// Zaokruži broj num na x decimala
function round(num, x) {
    let d = Math.pow(10, x);
    return Math.round(num * d) / d
}

/// Stvara tablicu određenog id-a broja redaka i stupaca
/// Prvi argument: id tablice
/// Drugi argument: broj redaka koji će se stvoriti u tablici
/// Treći argument: broj stupaca za svaki redak
/// Ćetvrti argument: niz nizova (matrica) 
/// ako je niz nizova, npr. [[a, b, c], [1, 2, 3]] - tablica će imati 3 retka i 2 stupca
/// izgled tablice će biti:
/// a   1
/// b   2
/// c   3
/// NAPOMENA: Tablica se stvara u memoriji, ali se ne dodaje u DOM
function stvoriTablicu(id, brojRedaka, brojStupaca, nizNizova) {

    let table = document.createElement('table');
    let tbody = document.createElement('tbody');
    table.id = id;
    table.classList.add('matrix-table');
    table.style.width = "inherit";

    for (let i = 0; i < brojRedaka; i++) {
        let tr = document.createElement('tr');

        for (let j = 0; j < brojStupaca; j++) {
            let td = document.createElement('td');
            td.style.paddingBottom = '5px';
            if (j > 0) {
                td.style.paddingLeft = '5px';
            }
            td.innerHTML = nizNizova[j][i];
            tr.appendChild(td);
        }

        tbody.appendChild(tr);
    }
    table.appendChild(tbody);

    return table;
}

/// dodat ce HTML elemente kao posljednje dijete body elementa koji će prikazati sadržaj niza
/// prvi parametar: niz
/// drugi parametar (opcionalan): poruka koja će se ispisati prije
function ispisiNiz(niz, poruka = '') {

    const prefix = idPrefixes.getForArrayPrint();
    const nextId = getNextId(prefix);

    const tekst = niz.reduce((a, b) => a.toString() + ',' + b);
    const opis = document.createTextNode(poruka);
    const tekstNode = document.createTextNode(tekst);
    const div = document.createElement('div');
    if (poruka !== '') {
        div.appendChild(opis);
        div.appendChild(document.createElement('br'));
    }
    div.appendChild(tekstNode);
    div.id = nextId;
    document.body.appendChild(div);
}

/// dodat ce u HTML elemente na body potrebne za ispis matrice
/// pretpostavka da je matrica niz nizova, oblika, npr. let a = [][];
function ispisiMatricu(matrica, koristiCss = false, divwidth = '100%') {

    const nextId = getNextId(idPrefixes.getForTableContainer());

    const div = document.createElement('div');
    div.id = idPrefixes.getForTableContainer() + nextId;
    div.style.width = divwidth;
    const table = document.createElement('table');

    if (koristiCss) {
        table.classList.add('matrix-table');
    }

    const thead = document.createElement('thead');
    const tbody = document.createElement('tbody');

    const rows = matrica.length;
    const max_cols = matrica.reduce((max, row) => row.length > max ? row.length : max, 0);

    for (let i = 0; i < max_cols + 1; i++) {

        const td = document.createElement('td');
        const column_number = document.createTextNode((i - 1) >= 0 ? (i - 1) : '');
        td.style.paddingBottom = '5px';

        if (koristiCss) {
            td.classList.add('matrix-cell');
        }

        td.appendChild(column_number);
        thead.appendChild(td);
    }

    if (koristiCss) {
        thead.classList.add('matrix-head');
    }

    for (let i = 0; i < rows; i++) {
        const tr = document.createElement('tr');

        const indexTd = document.createElement('td');
        const indexNode = document.createTextNode(i);
        indexTd.style.paddingRight = '10px';
        if (koristiCss) {
            indexTd.classList.add('matrix-cell');
        }
        indexTd.appendChild(indexNode);
        tr.appendChild(indexTd);

        for (let j = 0; j < max_cols; j++) {
            const td = document.createElement('td');
            const textNode = document.createTextNode(matrica[i][j]); // namjerno ćemo ispisati undefined da se vidi da nisu postavljeni svi elementi matrice            
            if (koristiCss) {
                td.classList.add('matrix-cell');
            }
            td.appendChild(textNode);
            tr.appendChild(td);
        }
        tbody.appendChild(tr);
    }

    table.appendChild(thead);
    table.appendChild(tbody);

    div.appendChild(table);
    document.body.appendChild(div);
}

/// briše element sa HTML stranice po ID-u.
function izbrisiElement(id) {
    const el = document.getElementById(id);
    if (el === null || el === undefined) return;
    el.parentNode.removeChild(el);
}