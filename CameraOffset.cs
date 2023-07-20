using Cinemachine;
using HarmonyLib;
using UnityEngine;

namespace MFFix;

[HarmonyPatch(typeof(GameMananger)), HarmonyPatch("LevelUp")]
public class CameraOffset
{
    [HarmonyPostfix]
    public static void LevelUpOffset(int in_Tier, GameMananger __instance)
    {
        CinemachineFreeLook cinFreeLook =
            Traverse.Create(__instance).Field<CinemachineFreeLook>("_cameraController").Value;

        for (int i = 0; i < 3; i++)
            cinFreeLook.GetRig(0).GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
                new Vector3(0, 10 * in_Tier, -10 * in_Tier);
        
        MFFix.Log("Camera offset applied: " + cinFreeLook.GetRig(0).GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset);
    }
}