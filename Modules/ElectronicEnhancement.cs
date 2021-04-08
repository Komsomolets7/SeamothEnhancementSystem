using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;

namespace SeamothEnhancementSystem.Modules
{
    class ElectronicEnhancement : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public ElectronicEnhancement() : base("ElectronicEnhancement", "Electronic module", "Part of Vehicle Enhancement System supplying Cruise Control and Turbo and Green engine modes")
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
                    new Ingredient(TechType.VehiclePowerUpgradeModule, 1),
                    new Ingredient(TechType.ComputerChip,1),
                    new Ingredient(TechType.AdvancedWiringKit, 1),
                },
            };
        }
        public override string AssetsFolder { get; } = MainPatcher.AssetsFolder;
    }
}
