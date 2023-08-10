using System;
using HarmonyLib;

namespace MFFix
{
  [HarmonyPatch(typeof(CanvasController)), HarmonyPatch("SavePlayTime")]
  public class StatsFix
  {
    /// <summary>
    /// Literally the only thing this does is prevent the original code from running.
    /// Fixes the issue with score being added twice.
    /// </summary>
    [HarmonyPrefix]
    public static bool SavePlayTime(object sender, EventArgs e, CanvasController __instance)
    {
      // Should run the LegacyStatsText();
      Traverse.Create(__instance).Method("LegacyStatsText").GetValue();
      
      return false;
    }
  }
}