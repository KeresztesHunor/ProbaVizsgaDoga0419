import ValaszOpcio from "./ValaszOpcio.js";

export default class Kerdes
{
    #megvalaszolva;
    #kerdes;
    #kerdesIndex;
    #valaszok;

    constructor(szuloElem, kerdes, kerdesIndex)
    {
        this.#megvalaszolva = false;
        this.#kerdes = kerdes;
        this.#kerdesIndex = kerdesIndex;
        szuloElem.append(`
            <div class="teszt">
                <div class="kerdes">${kerdes.kerdes}</div>
                <div class="valaszok"></div>
            </div>
        `)
        const kerdesElem = szuloElem.children(".teszt:last-child").children(".valaszok");
        this.#valaszok = {};
        this.#valaszok["V1"] = new ValaszOpcio(kerdesElem, kerdes.v1, "V1", kerdesIndex);
        this.#valaszok["V2"] = new ValaszOpcio(kerdesElem, kerdes.v2, "V2", kerdesIndex);
        this.#valaszok["V3"] = new ValaszOpcio(kerdesElem, kerdes.v3, "V3", kerdesIndex);
        this.#valaszok["V4"] = new ValaszOpcio(kerdesElem, kerdes.v4, "V4", kerdesIndex);
    }

    get megvalaszolva()
    {
        return this.#megvalaszolva;
    }

    get kerdes()
    {
        return this.#kerdes;
    }

    get kerdesIndex()
    {
        return this.#kerdesIndex;
    }

    setMegvalaszolva()
    {
        this.#megvalaszolva = true;
    }

    valasz(valaszId, helyes)
    {
        if (helyes)
        {
            this.#valaszok[valaszId].helyesValasz();
        }
        else
        {
            this.#valaszok[valaszId].helytelenValasz();
        }
    }
}