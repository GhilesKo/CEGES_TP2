using System.ComponentModel.DataAnnotations;

namespace CEGES_Core
{
    public enum EquipementType
    {
        [Display(Name = "Constant")]
        Constant,

        [Display(Name = "Linéaire")]
        Lineaire,

        [Display(Name = "Relatif")]
        Relatif
    }
}
