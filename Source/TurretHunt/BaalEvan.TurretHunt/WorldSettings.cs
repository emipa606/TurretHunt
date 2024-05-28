using RimWorld.Planet;
using Verse;

namespace BaalEvan.TurretHunt;

public class WorldSettings(World world) : WorldComponent(world)
{
    private TurretHuntSettings turretHunt;

    public TurretHuntSettings TurretHunt
    {
        get
        {
            TurretHuntSettings result;
            if ((result = turretHunt) == null)
            {
                result = turretHunt = new TurretHuntSettings();
            }

            return result;
        }
        set => turretHunt = value;
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Deep.Look(ref turretHunt, "turretHunt");
    }
}