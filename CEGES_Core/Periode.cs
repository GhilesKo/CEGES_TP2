using CEGES_Util;
using System;
using System.Collections.Generic;

namespace CEGES_Core
{
    public class Periode
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public List<Mesure> Mesures { get; set; }
        public int EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; }
        public Periode()
        {

        }

        public Periode(DateTime dateDebut)
        {
            Debut = dateDebut;
            Fin = dateDebut.AddMonths(1).AddDays(-1);
            Nom = dateDebut.ToString("MMMM yyyy").CapitalizeFirst();
        }
    }
}
