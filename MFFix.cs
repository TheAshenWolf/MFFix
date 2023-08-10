using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MFFix
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class MFFix : BaseUnityPlugin
    {
        // TODO: Possibly move those into a config file?
        private static readonly ManualLogSource _mfFixLogger = BepInEx.Logging.Logger.CreateLogSource("MFFix");
        private const bool ENABLE_LOG = true;

        public static void Log(string message)
        {
            if (ENABLE_LOG) _mfFixLogger.LogInfo(message);
        }


        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }
}