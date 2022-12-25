export default class Periode {
    constructor(
        public id: number,
        public entreprise: string,
        public nom: string,
        public debut: Date,
        public fin: Date) {

    }
}