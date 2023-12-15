using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesterWindUp
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(GUID);

        private const string GUID = "oe.tweaks.sounds.jester";
        private const string NAME = "Jester Wind Up Sound";
        private const string VERSION = "1.0.0";

        internal static Plugin instance;

        internal static ManualLogSource log;

        private void Awake()
        {
            log = this.Logger;
            log.LogInfo($"'{NAME}' is loading...");

            if (instance == null)
                instance = this;

            harmony.PatchAll();

            log.LogInfo($"'{NAME}' loaded!");
        }
    }
}
