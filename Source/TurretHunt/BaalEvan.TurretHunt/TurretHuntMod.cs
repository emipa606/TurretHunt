using HarmonyLib;
using Verse;

namespace BaalEvan.TurretHunt
{
    public class TurretHuntController : Mod
    {
        private static TurretHuntController instance;
        public static TurretHuntController Instance => instance;

        private WorldSettings worldSettings;
        public WorldSettings WorldSettings
        {
            get
            {
                if (worldSettings == null && Find.World != null)
                {
                    worldSettings = Find.World.GetComponent<WorldSettings>();
                }
                return worldSettings;
            }
        }

        public TurretHuntController(ModContentPack content) : base(content)
        {
            instance = this;
            new Harmony("BaalEvan.TurretHunt").PatchAll();
        }

        public static class Logger
        {
            public static void Message(string message)
            {
                Log.Message("[TurretHunt] " + message);
            }

            public static void Warning(string message)
            {
                Log.Warning("[TurretHunt] " + message);
            }

            public static void Error(string message)
            {
                Log.Error("[TurretHunt] " + message);
            }
        }
    }
}