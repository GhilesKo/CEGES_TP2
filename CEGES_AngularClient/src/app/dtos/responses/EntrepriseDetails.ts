import EquipementDetails from "./EquipementDetails";
import GroupeSommaire from "./GroupeSommaire";

export default class EntrepriseDetails {
    constructor(
        public nom:string, 
        public total: number,
        public equipements: EquipementDetails[]) {

    }
}

