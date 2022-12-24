export default class EquipementDetails {
    constructor(
        public id: number,
        public nom: string,
        public groupe: string,
        public type: string,
        public emission: number,
        public emissionAnterieure: number,
        public pourcentage: number) { }
}