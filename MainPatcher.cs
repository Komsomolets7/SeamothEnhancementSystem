using System.IO;
using System.Reflection;
using SeamothEnhancementSystem.Modules;
using SeamothEnhancementSystem.Configuration;
using Harmony;
using SMLHelper.V2.Handlers;
using QModManager.API.ModLoading;
using UnityEngine;
using UnityEngine.UI;


namespace SeamothEnhancementSystem     // Line matching mod name.
{
    [QModCore]
    public class MainPatcher
    {
        public static string _AssetName => "seamothguibundle";
        private static Assembly thisAssembly = Assembly.GetExecutingAssembly();
        private static string ModPath = Path.GetDirectoryName(thisAssembly.Location);
        internal static string AssetsFolder = Path.Combine(ModPath, "Assets");
        internal static AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(AssetsFolder, "seamothguibundle"));

        [QModPatch]
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.mimes.subnautica.seamothenhancementsystem");   // Name to match mod.

            // Create Seamoth addon modules (for crafting in Moonpool)
            var electricalEnhancement = new ElectricalEnhancement();
            electricalEnhancement.Patch();
            var electronicEnhancement = new ElectronicEnhancement();
            electronicEnhancement.Patch();
            var mechanicalEnhancement = new MechanicalEnhancement();
            mechanicalEnhancement.Patch();
            var seamothLink = new SeamothLink();
            seamothLink.Patch();

            // Create Seamoth addon modules (for crafting Vehicle Modification Station)
            var seamothEnhancementSystem = new SeamothEnhancementSystemModule();
            seamothEnhancementSystem.Patch();

            // Load icon for extra "Vehicle piloting enhancements" entry
            GameObject thisGameObject = new GameObject("VehicleEnhancements");
            Sprite thisSprite = MainPatcher.assetBundle.LoadAsset<Sprite>("piloting_128x128");
            thisGameObject.gameObject.AddComponent<Image>().sprite = thisSprite;

            // Create extra node
            CraftTreeHandler.AddTabNode(CraftTree.Type.SeamothUpgrades, "vehicleEnhancements", "Vehicle piloting enhancements", thisSprite);
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.SeamothUpgrades, electricalEnhancement.TechType, new string[] { "vehicleEnhancements" });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.SeamothUpgrades, electronicEnhancement.TechType, new string[] { "vehicleEnhancements" });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.SeamothUpgrades, mechanicalEnhancement.TechType, new string[] { "vehicleEnhancements" });
            CraftTreeHandler.AddCraftingNode(CraftTree.Type.SeamothUpgrades, seamothLink.TechType, new string[] { "vehicleEnhancements" });

            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options.Options());
        }
    }
}
