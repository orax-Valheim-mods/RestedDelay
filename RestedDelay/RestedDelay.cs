using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace RestedDelay
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class RestedDelay : BaseUnityPlugin
    {
        public const string PluginGUID = "orax.RestedDelay";
        public const string PluginName = "Rested delay";
        public const string PluginVersion = "0.1.0";

        public static ConfigEntry<float> restedDelay;

        private static Harmony _hi;

        private void Awake()
        {
            restedDelay = Config.Bind("General", "Rested delay", 0f,
                "Time in seconds before getting rested status. Rested is a status effect applied after having the Resting effect for 20 seconds (game default settings).");

            _hi = new Harmony(PluginGUID);
            _hi.PatchAll();
        }

        private void OnDestroy()
        {
            _hi?.UnpatchSelf();
        }
    }
}
