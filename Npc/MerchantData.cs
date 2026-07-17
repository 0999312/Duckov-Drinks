using FeatherMod;
using FeatherMod.Items;
using FeatherMod.Utils;
using System.Collections.Generic;

namespace DuckovDrinks.Npc
{
    /// <summary>
    /// 老政商人商品配置。
    /// 明面商品在 NPC 出现时即解锁，暗面商品通过任务逐步解锁。
    /// </summary>
    public static class MerchantData
    {
        /// <summary>
        /// 注册商人 Profile 和基础商品（新版 Identifier API）。
        /// </summary>
        public static void Register()
        {
            ShopUtils.CreateMerchantProfile(NpcConfig.MerchantProfileId);

            GameItemLookup.TryGetIdentifier(428, out var water);

            foreach (var goods in GetBaseGoods(water))
                ShopUtils.AddGoods(goods, Constants.MODID);
        }

        /// <summary>
        /// 注册可解锁商品（初始 forceUnlock=false，由任务奖励激活）。
        /// </summary>
        public static void RegisterUnlockableGoods()
        {
            GameItemLookup.TryGetIdentifier(888, out var apple);
            GameItemLookup.TryGetIdentifier(1011, out var orange);

            foreach (var goods in GetUnlockableGoods(apple, orange))
                ShopUtils.AddGoods(goods, Constants.MODID);
        }

        private static IReadOnlyList<ShopGoodsData> GetBaseGoods(Identifier? water)
        {
            return new[]
            {
                new ShopGoodsData
                {
                    merchantProfileID = NpcConfig.MerchantProfileId.Path,
                    itemIdentifier = new Identifier(Constants.MODID, Constants.ITEM_WHITE_SUGAR),
                    maxStock = 10,
                    priceFactor = 1.0f,
                    forceUnlock = true,
                },
                new ShopGoodsData
                {
                    merchantProfileID = NpcConfig.MerchantProfileId.Path,
                    itemIdentifier = new Identifier(Constants.MODID, Constants.ITEM_WHOLE_MILK),
                    maxStock = 5,
                    priceFactor = 1.0f,
                    forceUnlock = true,
                },
                new ShopGoodsData
                {
                    merchantProfileID = NpcConfig.MerchantProfileId.Path,
                    itemIdentifier = water,
                    maxStock = 8,
                    priceFactor = 1.2f,
                    forceUnlock = true,
                },
            };
        }

        private static IReadOnlyList<ShopGoodsData> GetUnlockableGoods(Identifier? apple, Identifier? orange)
        {
            return new[]
            {
                new ShopGoodsData
                {
                    merchantProfileID = NpcConfig.MerchantProfileId.Path,
                    itemIdentifier = apple,
                    maxStock = 5,
                    priceFactor = 1.0f,
                    forceUnlock = false,
                },
                new ShopGoodsData
                {
                    merchantProfileID = NpcConfig.MerchantProfileId.Path,
                    itemIdentifier = orange,
                    maxStock = 5,
                    priceFactor = 1.0f,
                    forceUnlock = false,
                },
            };
        }
    }
}
