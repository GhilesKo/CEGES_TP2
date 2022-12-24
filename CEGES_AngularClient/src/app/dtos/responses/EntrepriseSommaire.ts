import GroupeSommaire from "./GroupeSommaire";

export default class EntrepriseSommaire {
    constructor(
        public nom: string,
        public total: number,
        public groupes: GroupeSommaire[]
        ) {
    }
}

