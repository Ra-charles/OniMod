using System.Collections.Generic;
using PeterHan.PLib.Buildings;
using TUNING;
using UnityEngine;


namespace IceBox
{
    public class IceBoxConfig : IBuildingConfig
    {
        internal static PBuilding RegisterBuilding()
        {
            IceBoxConfig.pBuilding = new PBuilding(id, STRINGS.BUILDINGS.PREFABS.ICEBOX.NAME)
            {
                AddAfter = "Refrigerator",
                Animation = "icebox_kanim",
                AudioCategory = "Metal",
                Category = "Food",
                ConstructionTime = 120f,
                Description = STRINGS.BUILDINGS.PREFABS.ICEBOX.DESC,
                EffectText = STRINGS.BUILDINGS.PREFABS.ICEBOX.EFFECT,
                Entombs = true,
                ExhaustHeatGeneration = 0,
                Floods = true,
                DefaultPriority = 6,
                HeatGeneration = 0f,
                Height = 3,
                Width = 3,
                HP = 100,
                IndustrialMachine = false,
                OverheatTemperature = null,
                Placement = BuildLocationRule.OnFloor,
                RotateMode = PermittedRotations.FlipH,
                SubCategory = "Food",
                Tech = "FineDining",
                ViewMode = OverlayModes.Power.ID,
            };
            return IceBoxConfig.pBuilding;
        }

        public override BuildingDef CreateBuildingDef()
        {
            string id = "IceBox";
            int hight = 3;
            int with = 3;
            string knim = "icebox_kanim";
            int num3 = 30;
            float num4 = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] raw_MINERALS = MATERIALS.RAW_MINERALS;
            float num5 = 800f;
            BuildLocationRule buildLocationRule = (BuildLocationRule)1;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER0;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, hight,with, knim, num3, num4, tier, raw_MINERALS, num5, buildLocationRule, BUILDINGS.DECOR.BONUS.TIER1, tier2, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.EnergyConsumptionWhenActive = Settings.GetSettings().DefultPower;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.LogicInputPorts = new List<LogicPorts.Port>
            {
                LogicPorts.Port.OutputPort(FilteredStorage.FULL_PORT_ID,new CellOffset(0,0),STRINGS.BUILDINGS.PREFABS.ICEBOX.LOGIC_PORT,STRINGS.BUILDINGS.PREFABS.ICEBOX.LOGIC_PORT_ACTIVE,STRINGS.BUILDINGS.PREFABS.ICEBOX.LOGIC_PORT_INACTIVE,false,false),
            };
            buildingDef.Floodable = true;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "Metal";
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Storage storage = EntityTemplateExtensions.AddOrGet<Storage>(go);
            storage.showInUI = true;
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.FOOD;
            storage.allowItemRemoval = true;
            storage.capacityKg = Settings.GetSettings().Defultstorage;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = (Storage.FetchCategory)1;
            storage.showCapacityStatusItem = true;
            Prioritizable.AddRef(go);
            EntityTemplateExtensions.AddOrGet<TreeFilterable>(go);
            EntityTemplateExtensions.AddOrGet<Refrigerator>(go);
            RefrigeratorController.Def def = EntityTemplateExtensions.AddOrGetDef<RefrigeratorController.Def>(go);
            def.powerSaverEnergyUsage = 66f;
            def.coolingHeatKW = 0f;
            def.steadyHeatKW = 0f;
            EntityTemplateExtensions.AddOrGet<UserNameable>(go);
            EntityTemplateExtensions.AddOrGet<DropAllWorkable>(go);
            EntityTemplateExtensions.AddOrGetDef<StorageController.Def>(go);
        }

        public static string id = "IceBox";

        public static PBuilding pBuilding;
        
    }
}
