using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RimFridge
{
    internal static class RimFridgeSettingsUtil
    {
        public static Dictionary<string, float> BaseEnergy { get; set; }
        public static Dictionary<string, ThingDef> FridgeDefs { get; set; }

        static RimFridgeSettingsUtil()
        {
            BaseEnergy = null;
        }

        private static void CreateBaseEnergyMap()
        // Unsure if this is still necessary due to below message, keeping just in case.
        {
            if (BaseEnergy == null)
            {
                BaseEnergy = new Dictionary<string, float>();
                FridgeDefs = new Dictionary<string, ThingDef>();
                foreach (ThingDef def in DefDatabase<ThingDef>.AllDefsListForReading)
                {
                    if (def.defName.StartsWith("RimFridge"))
                    {
                        var power = def.GetCompProperties<CompProperties_Power>();
                        if (power != null)
                        {
                            BaseEnergy.Add(def.defName, power.PowerConsumption);
                            FridgeDefs.Add(def.defName, def);
                        }
                    }
                }
            }
        }

        public static void ApplyFactor(float newFactor)
        {
            //This function was rendered unusable by the 1.4 update. 
        }
    }
}
