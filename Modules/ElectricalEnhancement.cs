using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;

namespace SeamothEnhancementSystem.Modules
{
    class ElectricalEnhancement : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public ElectricalEnhancement() : base("ElectricalEnhancement", "Electrical module", "Part of Vehicle Enhancement System supplying Advanced Headlights and in-cabin Battery Exchange")
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
                    new Ingredient(TechType.Battery, 1),
                    new Ingredient(TechType.ComputerChip,1),
                    new Ingredient(TechType.WiringKit, 1),
                },
            };
        }
        public override string AssetsFolder { get; } = MainPatcher.AssetsFolder;
    }
}
