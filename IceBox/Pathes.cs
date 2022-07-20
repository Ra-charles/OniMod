using HarmonyLib;
using KMod;
using PeterHan.PLib.Buildings;
using PeterHan.PLib.Core;
using PeterHan.PLib.Database;
using PeterHan.PLib.Options;
using UnityEngine;

namespace IceBox
{
    internal class IceBoxPatches : UserMod2
    {
		public override void OnLoad(Harmony harmony)
		{
			base.OnLoad(harmony);
			PUtil.InitLibrary(false);
			new PLocalization().Register(null);
			PBuildingManager pbuildingManager = new PBuildingManager();
			pbuildingManager.Register(IceBoxConfig.RegisterBuilding());
			new POptions().RegisterOptions(this, typeof(Settings));
			Settings.Init(POptions.ReadSettings<Settings>());
		}
		[HarmonyPatch(typeof(RefrigeratorConfig))]
		[HarmonyPatch("CreateBuildingDef")]
		public class RefrigeratorConfig_Power_Sttings
		{
			private static void Postfix(BuildingDef __result)
			{
				__result.EnergyConsumptionWhenActive = Settings.GetSettings().RefrigeratorPower;
				__result.SelfHeatKilowattsWhenActive = Settings.GetSettings().RefrigeratorSelfHeatKilowattsWhenActive;
			}
		}
		[HarmonyPatch(typeof(RefrigeratorConfig))]
		[HarmonyPatch("DoPostConfigureComplete")]
		internal class RefrigeratorConfig_Str_Sttings
		{
			private static void Postfix(GameObject go)
			{
				EntityTemplateExtensions.AddOrGet<Storage>(go).capacityKg = Settings.GetSettings().RefrigeratorStorage;
			}
		}
		[HarmonyPatch(typeof(RefrigeratorController.Def), (MethodType)3)]
		public class RefrigeratorController_Def
		{
			private static void Postfix(ref float ___simulatedInternalTemperature)
			{
				___simulatedInternalTemperature = Settings.GetSettings().SimulatedInternalTemperature;
			}
		}
		[HarmonyPatch(typeof(Rottable), "AtmosphereQuality")]
		internal class Rottable_RotAtmosphereQuality
		{
			public static void Postfix(ref Rottable.RotAtmosphereQuality __result)
			{
				__result = (Rottable.RotAtmosphereQuality)1;
			}
		}
	}
}
