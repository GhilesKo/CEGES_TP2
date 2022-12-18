using CEGES_Core;

namespace CEGES_Core.Factories
{
    public static class EquipementFactory
    {
        public static Equipement CreateEquipement(EquipementType type)
        {
            return type switch
            {
                EquipementType.Constant => new EquipementConstant(),
                EquipementType.Lineaire => new EquipementLineaire(),
                EquipementType.Relatif => new EquipementRelatif(),
                _ => null
            };
        }
    }
}
