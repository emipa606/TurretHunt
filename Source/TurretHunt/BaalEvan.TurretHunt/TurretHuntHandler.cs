using System;
using System.Collections.Generic;
using HugsLib.Utils;
using RimWorld;
using Verse;
using Verse.AI;

namespace BaalEvan.TurretHunt;

public class TurretHuntHandler
{
    private static readonly List<HuntingTargetCandidate> huntingTargetCandidates = [];

    private static TurretHuntSettings WorldSettings => TurretHuntController.Instance.WorldSettings.TurretHunt;

    public static Pawn TryFindHuntingTarget(Building_TurretGun searcher, Predicate<Pawn> extraPredicate)
    {
        huntingTargetCandidates.Clear();
        var allPawnsSpawned = searcher.Map.mapPawns.AllPawnsSpawned;
        foreach (var pawn in allPawnsSpawned)
        {
            var minRange = searcher.AttackVerb.verbProps.EffectiveMinRange(pawn, searcher) *
                           searcher.AttackVerb.verbProps.EffectiveMinRange(pawn, searcher);
            var maxRange = searcher.AttackVerb.verbProps.range * searcher.AttackVerb.verbProps.range;
            if (PawnValidator(pawn, minRange, maxRange))
            {
                huntingTargetCandidates.Add(new HuntingTargetCandidate(pawn,
                    (searcher.Position - pawn.Position).LengthHorizontalSquared));
            }
        }

        huntingTargetCandidates.Sort();
        return huntingTargetCandidates.Count > 0 ? huntingTargetCandidates[0].target : null;

        bool PawnValidator(Pawn p, float min, float max)
        {
            if (p == null)
            {
                return false;
            }

            var lengthHorizontalSquared = (searcher.Position - p.Position).LengthHorizontalSquared;
            var inRange = lengthHorizontalSquared >= (double)min && lengthHorizontalSquared <= (double)max;
            var fogged = p.Position.Fogged(searcher.Map);
            var canSee = searcher.CanSee(p);
            var hasRace = p.RaceProps != null;
            var animal = p.RaceProps?.Animal ?? false;
            var hasFaction = p.Faction == null;
            var isDesignated = WorldSettings.TurretIsHuntingForDesignated(searcher);
            var hasDesignation = p.HasDesignation(DesignationDefOf.Hunt);
            var isHunting = WorldSettings.TurretIsHuntingForKill(searcher);
            var downed = p.Downed;
            return inRange && !fogged && canSee && hasRace && animal && hasFaction &&
                   (!isDesignated || hasDesignation) && (isHunting || !downed) &&
                   (extraPredicate == null || extraPredicate(p));
        }
    }

    private readonly struct HuntingTargetCandidate(Pawn target, int distanceSquared)
        : IComparable<HuntingTargetCandidate>
    {
        public readonly Pawn target = target;

        private readonly int distanceSquared = distanceSquared;

        public int CompareTo(HuntingTargetCandidate other)
        {
            return distanceSquared.CompareTo(other.distanceSquared);
        }
    }
}