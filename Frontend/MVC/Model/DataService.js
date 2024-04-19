export default class DataService
{
    #baseUrl;

    constructor(baseUrl)
    {
        this.#baseUrl = baseUrl;
    }

    get(utvonal, callback)
    {
        axios
            .get(this.#baseUrl + utvonal)
            .then(callback)
            .catch(console.error)
        ;
    }
}