import GroupeSommaire from "./GroupeSommaire";

export default class EntrepriseSommaireAvecVariations {
    constructor(
        public nom: string,
        public total: number,
        public totalPeriodeAnterieure: number,
        public groupes: GroupeSommaire[]
    ) {

    }
}

