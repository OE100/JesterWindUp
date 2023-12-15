using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JesterWindUp.Patches
{
    [HarmonyPatch(typeof(JesterAI))]
    internal class JesterAIPatch
    {
        private static AudioClip jesterWindUp = null;

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void patchJesterWindUpSound(JesterAI __instance)
        {
            Plugin.log.LogInfo("Patching JesterAI...");
            if (jesterWindUp == null)
            {
                AssetBundle ab = AssetBundle.LoadFromFile(Paths.PluginPath + "\\OE_Tweaks\\Sounds\\jestersounds");
                if (ab == null)
                {
                    Plugin.log.LogError("Failed to load jestersounds asset bundle");
                    return;
                }
                jesterWindUp = ab.LoadAsset<AudioClip>("jester_wind_up.mp3");
                __instance.popGoesTheWeaselTheme = jesterWindUp;
            }
        }
    }
}
