using RimWorld;
using UnityEngine;
using Verse;

namespace BaalEvan.TurretHunt.Commands;

internal class Command_TurretHunt_Designated : Command_Toggle
{
    private static readonly Vector2 overlayIconOffset = new Vector2(59f, 57f);

    private readonly Building_TurretGun turret;

    public Command_TurretHunt_Designated(Building_TurretGun turret)
    {
        this.turret = turret;
        icon = TurretHuntDefOf.Textures.turretHuntDesignated;
        defaultLabel = "TurretHuntDesignatedToggle_label".Translate();
        defaultDesc = "TurretHuntDesignatedToggle_desc".Translate();
        isActive = () => WorldSettings.TurretIsHuntingForDesignated(turret);
        toggleAction = ToggleAction;
    }

    private static TurretHuntSettings WorldSettings => TurretHuntController.Instance.WorldSettings.TurretHunt;

    public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
    {
        return base.GizmoOnGUI(topLeft, maxWidth, parms);
    }

    public override bool InheritFloatMenuInteractionsFrom(Gizmo other)
    {
        return false;
    }

    public static Gizmo TryGetGizmo(Building_TurretGun gun)
    {
        if (!gun.Active || !TurretHuntController.Instance.WorldSettings.TurretHunt.TurretIsHunting(gun))
        {
            return null;
        }

        return new Command_TurretHunt_Designated(gun);
    }

    private void ToggleAction()
    {
        TurretHuntController.Logger.Message("Command_TurretHunt - ToggleAction");
        WorldSettings.ToggleTurretDesignated(turret, !WorldSettings.TurretIsHuntingForDesignated(turret));
    }
}