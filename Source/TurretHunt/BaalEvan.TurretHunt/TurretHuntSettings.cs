using System.Collections.Generic;
using RimWorld;
using Verse;

namespace BaalEvan.TurretHunt;

public class TurretHuntSettings : IExposable
{
    private HashSet<int> turretsDesignated = [];
    private HashSet<int> turretsHunting = [];

    private HashSet<int> turretsKilling = [];

    public void ExposeData()
    {
        var list = new List<int>(turretsHunting);
        var list2 = new List<int>(turretsDesignated);
        var list3 = new List<int>(turretsKilling);
        Scribe_Collections.Look(ref list, "turrets");
        Scribe_Collections.Look(ref list2, "turretsKillDowned");
        Scribe_Collections.Look(ref list3, "turretsDesignated");
        turretsHunting = [..list];
        turretsDesignated = [..list2];
        turretsKilling = [..list3];
    }

    public bool TurretIsHunting(Building_TurretGun pawn)
    {
        return turretsHunting.Contains(pawn.thingIDNumber);
    }

    public bool TurretIsHuntingForDesignated(Building_TurretGun pawn)
    {
        return turretsHunting.Contains(pawn.thingIDNumber) && turretsDesignated.Contains(pawn.thingIDNumber);
    }

    public bool TurretIsHuntingForKill(Building_TurretGun pawn)
    {
        return turretsHunting.Contains(pawn.thingIDNumber) && turretsKilling.Contains(pawn.thingIDNumber);
    }

    public void ToggleTurretHunting(Building_TurretGun turret, bool enable)
    {
        var thingIDNumber = turret.thingIDNumber;
        if (enable)
        {
            turretsHunting.Add(thingIDNumber);
            turretsDesignated.Add(thingIDNumber);
        }
        else
        {
            turretsHunting.Remove(thingIDNumber);
        }
    }

    public void ToggleTurretDesignated(Building_TurretGun turret, bool enable)
    {
        var thingIDNumber = turret.thingIDNumber;
        if (TurretIsHunting(turret) != enable && enable)
        {
            ToggleTurretHunting(turret, true);
        }

        if (enable)
        {
            turretsDesignated.Add(thingIDNumber);
        }
        else
        {
            turretsDesignated.Remove(thingIDNumber);
        }
    }

    public void ToggleTurretKilling(Building_TurretGun turret, bool enable)
    {
        var thingIDNumber = turret.thingIDNumber;
        if (TurretIsHunting(turret) != enable && enable)
        {
            ToggleTurretHunting(turret, true);
        }

        if (enable)
        {
            turretsKilling.Add(thingIDNumber);
        }
        else
        {
            turretsKilling.Remove(thingIDNumber);
        }
    }
}