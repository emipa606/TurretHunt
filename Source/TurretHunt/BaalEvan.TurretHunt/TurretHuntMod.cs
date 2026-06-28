using HarmonyLib;
using Verse;

namespace BaalEvan.TurretHunt;

public class TurretHuntController : Mod
{
    public TurretHuntController(ModContentPack content) : base(content)
    {
        Instance = this;
        new Harmony("BaalEvan.TurretHunt").PatchAll();
    }

    public static TurretHuntController Instance { get; private set; }

    public WorldSettings WorldSettings
    {
        get
        {
            if (field == null && Find.World != null || field?.world != Find.World && Find.World != null)
            {
                field = Find.World.GetComponent<WorldSettings>();
            }

            return field;
        }
    }

    public static class Logger
    {
        public static void Message(string message)
        {
            Log.Message($"[TurretHunt] {message}");
        }

        public static void Warning(string message)
        {
            Log.Warning($"[TurretHunt] {message}");
        }

        public static void Error(string message)
        {
            Log.Error($"[TurretHunt] {message}");
        }
    }
}