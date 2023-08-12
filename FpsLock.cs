using Cinemachine;
using HarmonyLib;
using UnityEngine;

namespace MFFix
{
  [HarmonyPatch(typeof(SettingsManager)), HarmonyPatch("Start")]
  public class FpsLock
  {
    /// <summary>
    /// For some reason, setting vSyncCount to 1 does not lock the FPS to 60 for me.
    /// This patch sets target FPS to 60, so one can lock the framerate at 60 fps with vSync off.
    /// At the moment I am not sure whether this is the issue of the game, windows or Unity.
    /// </summary>
    [HarmonyPostfix]
    public static void Postfix()
    {
      Application.targetFrameRate = 60;
    }
  }
}