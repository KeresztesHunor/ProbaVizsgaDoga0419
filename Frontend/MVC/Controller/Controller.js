import DataService from "../Model/DataService.js";
import Kerdes from "../View/Kerdes.js";

export default class Controller
{
    #dataService;
    #kerdesek;
    #tesztElem;
    #helyesValaszokSzama;
    #helyesValaszokElem;

    constructor()
    {
        this.#dataService = new DataService("http://localhost:5150");
        this.#tesztElem = $("#teszt");
        this.#helyesValaszokElem = $("#helyes-valaszok");
        this.#dataService.get("/kategoriak", response => {
            const kategoriakElem = $("#kategoriak");
            kategoriakElem.html("<select></select>");
            const selectElem = kategoriakElem.children("select");
            response.data.forEach(kategoria => {
                selectElem.append(`
                    <option value="${kategoria.id}">${kategoria.kategoriaNev}</option>
                `);
            });
            this.#initKerdesek(1);
            selectElem.on("change", () => {
                this.#initKerdesek(selectElem.val());
            });
        });
        $(window).on("valaszraKattintott", event => {
            const kerdes = this.#kerdesek[event.detail.kerdesId];
            if (!kerdes.megvalaszolva)
            {
                if (event.detail.valaszId === kerdes.kerdes.helyes)
                {
                    kerdes.valasz(event.detail.valaszId, true);
                    this.#helyesValaszokElem.html("Helyes válaszok: " + ++this.#helyesValaszokSzama);
                }
                else
                {
                    kerdes.valasz(event.detail.valaszId, false);
                }
                kerdes.setMegvalaszolva();
            }
        });
    }

    #initKerdesek(kategoriaId)
    {
        this.#kerdesek = [];
        this.#tesztElem.html("");
        this.#helyesValaszokSzama = 0;
        this.#helyesValaszokElem.html("Helyes válaszok: 0");
        this.#dataService.get("/tesztek/kategoria/" + kategoriaId, response => {
            response.data.forEach((kerdes, index) => {
                this.#kerdesek.push(new Kerdes(this.#tesztElem, kerdes, index));
            });
        });
    }
}