using HarmonyLib;
using KMod;
using UnityEngine;

namespace LadderFast
{
    internal class Patches : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
        }
        [HarmonyPatch(typeof(LadderConfig))]
        [HarmonyPatch(nameof(LadderConfig.ConfigureBuildingTemplate))]
        internal class Lader_Fast
        {
            private static void Postfix(GameObject go)
            {
                // EntityTemplateExtensions 实体模板扩展.
                EntityTemplateExtensions.AddOrGet<Ladder>(go).upwardsMovementSpeedMultiplier = 6f;
                EntityTemplateExtensions.AddOrGet<Ladder>(go).downwardsMovementSpeedMultiplier = 6f;
            }
        }
    }
}
