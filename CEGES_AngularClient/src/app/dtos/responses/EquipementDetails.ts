export default class EquipementDetails {
    constructor(
        public nom: string,
        public groupe: string,
        public type: string,
        public emission: number,
        public emissionAnterieure: number,
        public pourcentage: number) { }
}