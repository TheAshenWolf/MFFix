using System;
using HarmonyLib;

namespace MFFix
{
  [HarmonyPatch(typeof(CanvasController)), HarmonyPatch("SavePlayTime")]
  public class StatsFix
  {
    /// <summary>
    /// Fixes the issue with score being added twice.
    /// </summary>
    [HarmonyPrefix]
    public static bool SavePlayTime(object sender, EventArgs e, CanvasController __instance)
    {
      // Runs the LegacyStatsText(); - this method is responsible for drawing the score on the screen.
      // This method was apparently never rewritten.
      Traverse.Create(__instance).Method("LegacyStatsText").GetValue();
      
      // Literally the only thing this does is prevent the original code from running.
      return false;
    }
  }
}