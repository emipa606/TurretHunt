using HarmonyLib;
using RimWorld;
using Verse;

namespace BaalEvan.TurretHunt.Patches;

[HarmonyPatch(typeof(Building_TurretGun), nameof(Building_TurretGun.TryFindNewTarget))]
internal static class Building_TurretGun_TryFindNewTarget
{
    public static bool Prefix(Building_TurretGun __instance, ref LocalTargetInfo __result)
    {
        if (!TurretHuntController.Instance.WorldSettings.TurretHunt.TurretIsHunting(__instance))
        {
            return true;
        }

        var pawn = TurretHuntHandler.TryFindHuntingTarget(__instance, null);
        if (pawn == null)
        {
            return true;
        }

        __result = pawn;
        return false;
    }
}