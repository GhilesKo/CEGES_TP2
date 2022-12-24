import EquipementDetails from "./EquipementDetails";

export default class EquipementDetailsAvecVariation {
    constructor(
        public nom: string,
        public total: string,
        public totalAnterieure: string,
        public equipements: EquipementDetails[]) { }
}