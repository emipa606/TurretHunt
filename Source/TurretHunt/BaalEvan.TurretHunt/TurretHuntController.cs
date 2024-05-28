using HugsLib;
using HugsLib.Utils;
using Verse;

namespace BaalEvan.TurretHunt;

public class TurretHuntController : ModBase
{
    private TurretHuntController()
    {
        Instance = this;
    }

    private ModLogger GetLogger => base.Logger;

    public static TurretHuntController Instance { get; private set; }

    internal new static ModLogger Logger => Instance.GetLogger;

    public override string ModIdentifier => "TurretHunt";

    public override string LogIdentifier => ModIdentifier;

    public override string SettingsIdentifier => ModIdentifier;

    public WorldSettings WorldSettings { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        Logger.Message("TurretHuntController - Initialize");
    }

    public override void WorldLoaded()
    {
        WorldSettings = Find.World.GetComponent<WorldSettings>();
    }
}