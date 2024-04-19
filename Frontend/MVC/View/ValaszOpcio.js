export default class ValaszOpcio
{
    #valasz;
    #valaszId;
    #kerdesId;
    #valaszElem;

    constructor(szuloElem, valasz, valaszId, kerdesId)
    {
        this.#valasz = valasz;
        this.#valaszId = valaszId;
        this.#kerdesId = kerdesId;
        szuloElem.append(`
            <button>${valasz}</button>
        `);
        this.#valaszElem = szuloElem.children("button:last-child");
        this.#valaszElem.on("click", () => {
            window.dispatchEvent(new CustomEvent("valaszraKattintott", { detail: this }))
        });
    }

    get valasz()
    {
        return this.#valasz;
    }

    get valaszId()
    {
        return this.#valaszId;
    }

    get kerdesId()
    {
        return this.#kerdesId;
    }

    helyesValasz()
    {
        this.#valaszElem.toggleClass("helyes");
    }

    helytelenValasz()
    {
        this.#valaszElem.toggleClass("helytelen");
    }
}