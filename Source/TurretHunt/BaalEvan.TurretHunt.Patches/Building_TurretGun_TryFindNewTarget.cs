using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BaalEvan.TurretHunt.Patches;

[HarmonyPatch]
internal static class Building_TurretGun_TryFindNewTarget
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(Building_TurretGun), nameof(Building_TurretGun.TryFindNewTarget));

        if (!ModsConfig.IsActive("CETeam.CombatExtended"))
        {
            yield break;
        }

        yield return AccessTools.Method("CombatExtended.Building_TurretGunCE:TryFindNewTarget");
    }

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