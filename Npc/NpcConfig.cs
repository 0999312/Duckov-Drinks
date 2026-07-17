using FeatherMod;
using FeatherMod.Items;
using FeatherMod.Utils;
using System.IO;
using UnityEngine;

namespace DuckovDrinks.Npc
{
    /// <summary>
    /// NPC 老政 — 零号区饮品铺老板。
    /// 通过建造饮品制作台（DrinkStation）后出现在基地中。
    /// 角色：商人 + 任务发布者。
    /// 捏脸通过 FaceRef.FromJson 在注册时直接内联。
    /// </summary>
    public static class NpcConfig
    {
        public static readonly Identifier Id = new Identifier(Constants.MODID, Constants.NPC_LAOZHENG);

        /// <summary>商人 Profile ID（Identifier 格式，Path 作为 merchantID）</summary>
        public static readonly Identifier MerchantProfileId = new Identifier(Constants.MODID, "Merchant_LaoZheng");

        /// <summary>QuestGiver ID（用于任务绑定）</summary>
        public const string QuestGiverId = "laozheng";

        /// <summary>
        /// 注册 NPC 预设（新版 API：FriendlyNpcUtils.RegisterFriendlyNpc）。
        /// 捏脸从 assets/npc/laozheng_face.json 加载，通过 FaceRef.FromJson 在注册时内联。
        /// 实际生成由饮品制作台建成回调触发，详见 BuildingConfig.RegisterOnBuiltCallback()。
        /// </summary>
        public static void Register()
        {
            var faceRef = LoadFaceRef();
            GameItemLookup.TryGetIdentifier(32, out var outfitId);
            var config = new FriendlyNpcConfig
            {
                DisplayNameKey = "npc_laozheng_name",
                ActorId = "laozheng",
                Role = NpcRole.Merchant,
                Face = faceRef,
                Model = ModelRef.Default,
                Team = Teams.middle,
                ShopId = MerchantProfileId.Path, // "Merchant_LaoZheng"
                QuestGiverId = QuestGiverId,
                SpawnRotation = Quaternion.identity,
                BodyEquipment = ItemEntry.Of(outfitId, 1)
            };

            FriendlyNpcUtils.RegisterFriendlyNpc(Id, config);

        }

        /// <summary>
        /// 从 assets/npc/laozheng_face.json 加载捏脸，返回 FaceRef.FromJson 结果。
        /// 文件缺失时回退为 FaceRef.Preset("Duck_Default")。
        /// </summary>
        private static FaceRef LoadFaceRef()
        {
            var modDir = ModPathResolver.ResolveDirectory(Constants.MODID);
            var facePath = Path.Combine(modDir, "assets", "npc", "laozheng_face.json");

            if (!File.Exists(facePath))
            {
                Debug.LogWarning($"[{Constants.MODID}] 捏脸文件未找到: {facePath}，使用默认脸");
                return FaceRef.Preset("Duck_Default");
            }

            var json = File.ReadAllText(facePath);
            return FaceRef.FromJson(json);
        }
    }
}
