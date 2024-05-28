using HugsLib.Utils;
using RimWorld;
using UnityEngine;
using Verse;

namespace BaalEvan.TurretHunt;

[DefOf]
public static class TurretHuntDefOf
{
    [StaticConstructorOnStartup]
    public static class Textures
    {
        public static Texture2D turretHunt;

        public static Texture2D turretHuntKill;

        public static Texture2D turretHuntDesignated;

        static Textures()
        {
            var fields = typeof(Textures).GetFields(HugsLibUtility.AllBindingFlags);
            foreach (var fieldInfo in fields)
            {
                fieldInfo.SetValue(null, ContentFinder<Texture2D>.Get(fieldInfo.Name));
            }
        }
    }
}