using System.Collections.Generic;
using BaalEvan.TurretHunt.Commands;
using HarmonyLib;
using RimWorld;
using Verse;

namespace BaalEvan.TurretHunt.Patches;

[HarmonyPatch(typeof(Building_TurretGun), nameof(Building_TurretGun.GetGizmos))]
internal static class Building_TurretGun_GetGizmos
{
    public static void Postfix(Building_TurretGun __instance, ref IEnumerable<Gizmo> __result)
    {
        var huntGizmo = Command_TurretHunt.TryGetGizmo(__instance);
        var designatedGizmo = Command_TurretHunt_Designated.TryGetGizmo(__instance);
        var killDownedGizmo = Command_TurretHunt_KillDowned.TryGetGizmo(__instance);
        if (huntGizmo != null)
        {
            __result = AppendGizmo(__result, huntGizmo);
        }

        if (designatedGizmo != null)
        {
            __result = AppendGizmo(__result, designatedGizmo);
        }

        if (killDownedGizmo != null)
        {
            __result = AppendGizmo(__result, killDownedGizmo);
        }
    }

    private static IEnumerable<Gizmo> AppendGizmo(IEnumerable<Gizmo> originalSequence, Gizmo addition)
    {
        foreach (var item in originalSequence)
        {
            yield return item;
        }

        yield return addition;
    }
}