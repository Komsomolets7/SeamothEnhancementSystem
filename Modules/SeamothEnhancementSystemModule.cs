using UnityEngine;
using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;

namespace SeamothEnhancementSystem.Modules
{
    public class SeamothEnhancementSystemModule : Equipable
    {
        public static TechType TechTypeID { get; protected set; }
        public SeamothEnhancementSystemModule() : base("SeamothEnhancementSystemModule", "Seamoth enhancement system", "Ads Advanced Headlights & in-cabin Battery Exchange, Cruise Control & Turbo and Green engine modes, Advanced Gearbox & Speedometer, enhances Health, Power and Temperature displays")
        {
            OnFinishedPatching += () =>
            {
                TechTypeID = this.TechType;
            };
        }
        public override EquipmentType EquipmentType => EquipmentType.SeamothModule;
        public override TechType RequiredForUnlock => TechType.Workbench;
        public override TechGroup GroupForPDA => TechGroup.VehicleUpgrades;
        public override TechCategory CategoryForPDA => TechCategory.VehicleUpgrades;
        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new string[] { "SeamothMenu" };
        public override QuickSlotType QuickSlotType => QuickSlotType.Passive;

        public override GameObject GetGameObject()
        {
            var prefab = CraftData.GetPrefabForTechType(TechType.SeamothElectricalDefense);
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
                    new Ingredient(ElectricalEnhancement.TechTypeID, 1),
                    new Ingredient(ElectronicEnhancement.TechTypeID,1),
                    new Ingredient(MechanicalEnhancement.TechTypeID, 1),
                    // new Ingredient(SeamothLink.TechTypeID, 1),
                },
            };
        }
        public override string AssetsFolder { get; } = MainPatcher.AssetsFolder;

    } // end public class SeamothEnhancementSystemModule : Equipable
}
