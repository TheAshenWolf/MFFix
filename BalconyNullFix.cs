using HarmonyLib;
using UnityEngine;

namespace MFFix
{
    [HarmonyPatch(typeof(BalconyChanger)), HarmonyPatch(nameof(BalconyChanger.DisconnectBalconies))]
    public class BalconyNullFix
    {
        /// <summary>
        /// Rewrite of the DisconnectBalconies() method to prevent null reference exceptions.
        /// </summary>
        /// <param name="__instance">Instance of <see cref="BalconyChanger"/> provided by Harmony</param>
        /// <returns>False - in order to block the original code from executing.</returns>
        [HarmonyPrefix]
        public static bool Prefix(BalconyChanger __instance)
        {
            MFFix.Log("Running patched version of DisconnectBalconies()");
        
            GameObject[] balconyArray = Traverse.Create(__instance).Field("_balconyArray").GetValue<GameObject[]>();
            foreach (GameObject balcony in balconyArray)
            {
                if (balcony != null) balcony.AddComponent<Rigidbody>();
            }

            return false;
        }
    }
}