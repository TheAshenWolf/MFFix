using Cinemachine;
using HarmonyLib;

namespace MFFix
{
  [HarmonyPatch(typeof(GameMananger)), HarmonyPatch("Initialize")]
  public class CameraOffsetInit
  {
    /// <summary>
    /// The intention was to change the distance of the camera from the player, with every level-up. However, Cinemachine
    /// is running on update loop or something, so it just resets the offset back whenever it is changed.
    /// This patch just increases the FOV slightly, which makes the camera appear further away and works a bit better than
    /// the initial value.
    /// </summary>
    /// <param name="__instance">Instance of <see cref="GameMananger"/> provided by Harmony</param>
    [HarmonyPostfix]
    public static void LevelUpOffset(GameMananger __instance)
    {
      MFFix.Log("Increasing camera FOV to 60.");

      CinemachineFreeLook cinFreeLook =
        Traverse.Create(__instance).Field<CinemachineFreeLook>("_cameraController").Value;

      cinFreeLook.m_Lens.FieldOfView = 60;
    }
  }
}