using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;

namespace SeamothEnhancementSystem.Modules
{
    public class MechanicalEnhancement : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public MechanicalEnhancement() : base("MechanicalEnhancement", "Mechanical module", "Part of Vehicle Enhancement System supplying Advanced Gearbox and Speedometer")
        {
            OnFinishedPatching += () =>
            {
                TechTypeID = this.TechType;
            };
        }

        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;
        public override TechType RequiredForUnlock => TechType.BaseUpgradeConsole;
        public override TechGroup GroupForPDA => TechGroup.VehicleUpgrades;
        public override TechCategory CategoryForPDA => TechCategory.VehicleUpgrades;
        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(TechType.SeamothReinforcementModule);
            var obj = GameObject.Instantiate(prefab);
            return obj;
        }

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients =
                {
                    new Ingredient(TechType.TitaniumIngot, 1),
                    new Ingredient(TechType.Diamond,1),
                    new Ingredient(TechType.Lubricant, 1),
                },
            };
        }
        public override string AssetsFolder { get; } = MainPatcher.AssetsFolder;
    }
}
