using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using Logger = BepInEx.Logging.Logger;

namespace MFFix;

[HarmonyPatch(typeof(BalconyChanger)), HarmonyPatch(nameof(BalconyChanger.DisconnectBalconies))]
public class BalconyNullFix
{
    [HarmonyPrefix]
    public static bool DisconnectBalconies(BalconyChanger __instance)
    {
        MFFix.Log("DisconnectBalconies() called");
        
        GameObject[] balconyArray = Traverse.Create(__instance).Field("_balconyArray").GetValue<GameObject[]>();
        foreach (GameObject balcony in balconyArray)
        {
            if (balcony != null) balcony.AddComponent<Rigidbody>();
        }

        return false;
    }
}