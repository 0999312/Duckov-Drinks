using FeatherMod;
using FeatherMod.Utils;
using System;
using UnityEngine;

namespace DuckovDrinks.Building
{
    /// <summary>
    /// 饮品制作台 — 占地 1×2，模型从 AssetBundle "drinks" 加载。
    /// 建造完成后生成老政 NPC（异步 API，回收时自动清理）。
    /// </summary>
    public static class BuildingConfig
    {
        public static readonly Identifier Id = new Identifier(Constants.MODID, Constants.BUILDING_DRINK_STATION);

        private const string BundleName = "drinks";
        private const string ModelPrefabName = "DrinkStation";
        private const int Cost = 3000;

        private static Action<Duckov.Buildings.Building>? _onBuiltCallback;
        private static bool _registered;

        /// <summary>
        /// 注册饮品站建筑：创建外壳 → 注册 → 注入 Bundle 模型。
        /// 幂等，重复调用安全。
        /// </summary>
        public static void Register()
        {
            if (_registered) return;
            _registered = true;
            BuildingUtils.RegisterBuilding(new FeatherMod.BuildingConfig
            {
                Id = Id,
                Dimensions = new Vector2Int(1, 2),
                Money = Cost,
            });

            // 注入自定义 3D 模型
            var bundle = AssetUtil.LoadBundle(BundleName);
            if (bundle == null)
            {
                Debug.LogError($"[{Constants.MODID}] 无法加载 AssetBundle: {BundleName}");
                return;
            }

            var modelPrefab = bundle.LoadAsset<GameObject>(ModelPrefabName);
            if (modelPrefab == null)
            {
                Debug.LogError($"[{Constants.MODID}] Bundle 中未找到模型: {ModelPrefabName}");
                return;
            }

            BuildingUtils.SetBuildingModel(Id, modelPrefab);
        }

        /// <summary>
        /// 注册建筑建成回调：异步生成老政 NPC。
        /// 捏脸已通过 NpcConfig.Register() 中的 FaceRef.FromJson 在注册时内联。
        /// NPC 装备已通过 NpcConfig.Register() 中的 EquipmentUtils 配置。
        /// </summary>
        public static void RegisterOnBuiltCallback()
        {
            _onBuiltCallback = async building =>
            {
                var spawnPos = building.transform.position + new Vector3(1.5f, 0f, 0f);

                await FriendlyNpcUtils.SpawnFriendlyNpcAsync(
                    Npc.NpcConfig.Id, spawnPos);
            };

            BuildingUtils.OnBuildingBuilt(Id, _onBuiltCallback);
        }

        /// <summary>
        /// 注册建筑回收回调：建筑被拆除/回收时，清理关联的 NPC。
        /// </summary>
        public static void RegisterOnDemolishedCallback()
        {
            BuildingUtils.OnBuildingDemolished(Id, building =>
            {
                FriendlyNpcUtils.RemoveNpc(Npc.NpcConfig.Id);
            });
        }
    }
}
