using Cinemachine;
using HarmonyLib;
using UnityEngine;

namespace MFFix;

// TODO: This patch doesnt have any effect; cinemachine just resets it
// [HarmonyPatch(typeof(GameMananger)), HarmonyPatch("LevelUp")]
// public class CameraOffset
// {
//     [HarmonyPostfix]
//     public static void LevelUpOffset(int in_Tier, GameMananger __instance)
//     {
//         CinemachineFreeLook cinFreeLook =
//             Traverse.Create(__instance).Field<CinemachineFreeLook>("_cameraController").Value;
//
//         for (int i = 0; i < 3; i++)
//             cinFreeLook.GetRig(i).GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
//                 new Vector3(0, 10 * in_Tier, -10 * in_Tier);
//         
//         MFFix.Log("Camera offset applied: " + cinFreeLook.GetRig(0).GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset);
//     }
// }


[HarmonyPatch(typeof(GameMananger)), HarmonyPatch("Initialize")]
public class CameraOffsetInit
{
    [HarmonyPostfix]
    public static void LevelUpOffset(GameMananger __instance)
    {
        MFFix.Log("Increasing camera FOV to 60.");
        
        CinemachineFreeLook cinFreeLook =
            Traverse.Create(__instance).Field<CinemachineFreeLook>("_cameraController").Value;

        cinFreeLook.m_Lens.FieldOfView = 60;
    }
}
