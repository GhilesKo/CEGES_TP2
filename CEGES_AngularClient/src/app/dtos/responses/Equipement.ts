export default class Equipement {
    constructor(
        public nom: string,
        public groupe: string,
        public type: string,
        public emission: number,
        public pourcentage:number,
        public emissionAnterieure: number,
        ) {

    }
}