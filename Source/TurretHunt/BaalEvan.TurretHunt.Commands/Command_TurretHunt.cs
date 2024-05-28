using RimWorld;
using UnityEngine;
using Verse;

namespace BaalEvan.TurretHunt.Commands;

public class Command_TurretHunt : Command_Toggle
{
    private static readonly Vector2 overlayIconOffset = new Vector2(59f, 57f);

    private readonly Building_TurretGun turret;

    public Command_TurretHunt(Building_TurretGun turret)
    {
        this.turret = turret;
        icon = TurretHuntDefOf.Textures.turretHunt;
        defaultLabel = "TurretHuntToggle_label".Translate();
        defaultDesc = "TurretHuntToggle_desc".Translate();
        isActive = () => WorldSettings.TurretIsHunting(turret);
        toggleAction = ToggleAction;
    }

    private static TurretHuntSettings WorldSettings => TurretHuntController.Instance.WorldSettings.TurretHunt;

    public override bool InheritFloatMenuInteractionsFrom(Gizmo other)
    {
        return false;
    }

    private void ToggleAction()
    {
        TurretHuntController.Logger.Message("Command_TurretHunt - ToggleAction");
        WorldSettings.ToggleTurretHunting(turret, !WorldSettings.TurretIsHunting(turret));
    }

    public static Gizmo TryGetGizmo(Building_TurretGun gun)
    {
        return !gun.Active ? null : new Command_TurretHunt(gun);
    }
}