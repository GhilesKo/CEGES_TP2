namespace CEGES_Core.ViewModels
{
    public class DetailMesureVM
    {
        public int Id { get; set; }
        public string Groupe { get; set; }
        public string Equipement { get; set; }
        public int EquipementId { get; set; }
        public string Type { get; set; }
        public string Formule { get; set; }
        public decimal Mesure { get; set; }
        public decimal Emissions { get; set; }
        public string UniteMesure { get; set; }
    }
}
