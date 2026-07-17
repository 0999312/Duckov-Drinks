using FeatherMod;
using System.Collections.Generic;

namespace DuckovDrinks
{
    /// <summary>
    /// 模组物品数据定义。每个物品包含 ItemData 和对应的 Identifier。
    /// </summary>
    public static class Items
    {
        public static ItemData Suanmeitang => new ItemData
        {
            itemId = 30001,
            order = 11,
            localizationKey = "Suanmeitang",
            localizationDesc = "Suanmeitang_Desc",
            weight = 0.6f,
            value = 2160,
            maxDurability = 2,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/drink_01.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 50f }
                }
            }
        };

        public static ItemData WholeMilk => new ItemData
        {
            itemId = 30002,
            order = 12,
            localizationKey = "WholeMilk",
            localizationDesc = "WholeMilk_Desc",
            weight = 0.26f,
            value = 300,
            quality = 2,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            maxStackCount = 5,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/drink_02.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 25f },
                    new HealData { healValue = 10}
                }
            }
        };

        public static ItemData IcedTea => new ItemData
        {
            itemId = 30003,
            order = 13,
            localizationKey = "IcedTea",
            localizationDesc = "IcedTea_Desc",
            weight = 0.6f,
            value = 3000,
            maxDurability = 2,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/iced_tea.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 25f, waterValue = 50f },
                    new AddBuffData { buff = 1091, chance = 1f },
                    new AddBuffData { buff = 1101, chance = 1f },
                }
            }
        };

        public static ItemData AppleMilk => new ItemData
        {
            itemId = 30004,
            order = 12,
            localizationKey = "AppleMilk",
            localizationDesc = "AppleMilk_Desc",
            weight = 0.5f,
            value = 2850,
            maxDurability = 2,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/apple_milk.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 30f, waterValue = 45f },
                    new HealData { healValue = 15}
                }
            }
        };

        public static ItemData WhiteSugar => new ItemData
        {
            itemId = 30005,
            order = 12,
            localizationKey = "WhiteSugar",
            localizationDesc = "WhiteSugar_Desc",
            weight = 0.5f,
            value = 200,
            quality = 1,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            tags = new List<string> { "Food" },
            spritePath = "items/white_sugar.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_food",
                useSound = string.Empty,
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 25f, waterValue = -50f }
                }
            }
        };

        public static ItemData OrangeSoda => new ItemData
        {
            itemId = 30006,
            order = 21,
            localizationKey = "OrangeSoda",
            localizationDesc = "OrangeSoda_Desc",
            weight = 0.8f,
            value = 2150,
            maxDurability = 3,
            quality = 5,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/orange_soda.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 35f },
                    new AddBuffData { buff = 1101, chance = 1f }
                }
            }
        };

        public static ItemData SodaCanLemon => new ItemData
        {
            itemId = 30007,
            order = 21,
            localizationKey = "SodaCanLemon",
            localizationDesc = "SodaCanLemon_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/lemon_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 35f },
                    new AddBuffData { buff = 1101, chance = 1f }
                }
            }
        };

        public static ItemData SodaCanApple => new ItemData
        {
            itemId = 30008,
            order = 21,
            localizationKey = "SodaCanApple",
            localizationDesc = "SodaCanApple_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/apple_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 35f },
                    new AddBuffData { buff = 1101, chance = 1f }
                }
            }
        };

        public static ItemData SodaCanOrange => new ItemData
        {
            itemId = 30009,
            order = 21,
            localizationKey = "SodaCanOrange",
            localizationDesc = "SodaCanOrange_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/orange_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 35f },
                    new AddBuffData { buff = 1101, chance = 1f }
                }
            }
        };

        // ===== v0.5.0 新增原料 =====

        /// <summary>咖啡豆 — 袋装 500g，每次手冲消耗约 20g</summary>
        public static ItemData CoffeeBeanPack => new ItemData
        {
            itemId = 30012,
            order = 15,
            localizationKey = "CoffeeBeanPack",
            localizationDesc = "CoffeeBeanPack_Desc",
            weight = 0.5f,
            value = 300,
            maxDurability = 25,
            quality = 2,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            maxStackCount = 3,
            tags = new List<string> { "Food", "CoffeeBean" },
            spritePath = "items/coffee_bean_pack.png",
        };

        /// <summary>绿茶茶包 — 单包装</summary>
        public static ItemData GreenTeaTeabag => new ItemData
        {
            itemId = 30013,
            order = 16,
            localizationKey = "GreenTeaTeabag",
            localizationDesc = "GreenTeaTeabag_Desc",
            weight = 0.02f,
            value = 20,
            quality = 1,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            maxStackCount = 20,
            tags = new List<string> { "Food" },
            spritePath = "items/green_tea_teabag.png",
        };

        /// <summary>红茶茶包 — 单包装</summary>
        public static ItemData BlackTeaTeabag => new ItemData
        {
            itemId = 30014,
            order = 17,
            localizationKey = "BlackTeaTeabag",
            localizationDesc = "BlackTeaTeabag_Desc",
            weight = 0.02f,
            value = 20,
            quality = 1,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            maxStackCount = 20,
            tags = new List<string> { "Food" },
            spritePath = "items/black_tea_teabag.png",
        };

        // ===== v0.5.0 饮品 =====

        /// <summary>黑咖啡 — 经典手冲咖啡，提神醒脑</summary>
        public static ItemData CoffeeBlack => new ItemData
        {
            itemId = 30041,
            order = 31,
            localizationKey = "CoffeeBlack",
            localizationDesc = "CoffeeBlack_Desc",
            weight = 0.3f,
            value = 350,
            maxDurability = 1,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/cup_coffee.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 40f, waterValue = 50f },
                    new AddBuffData { buff = 1082, chance = 1f },
                    new AddBuffData { buff = 1091, chance = 1f },
                    new ReturnItemData { itemTypeID = 131, display = false },
                }
            }
        };

        /// <summary>拿铁 — 浓缩咖啡与蒸汽牛奶的完美融合</summary>
        public static ItemData CoffeeLatte => new ItemData
        {
            itemId = 30042,
            order = 32,
            localizationKey = "CoffeeLatte",
            localizationDesc = "CoffeeLatte_Desc",
            weight = 0.35f,
            value = 500,
            maxDurability = 1,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/cup_latte.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 50f, waterValue = 50f },
                    new AddBuffData { buff = 1082, chance = 1f },
                    new HealData { healValue = 25},
                    new ReturnItemData { itemTypeID = 131, display = false },
                }
            }
        };

        /// <summary>绿茶 — 清香淡雅，可解毒素</summary>
        public static ItemData GreenTea => new ItemData
        {
            itemId = 30043,
            order = 33,
            localizationKey = "GreenTea",
            localizationDesc = "GreenTea_Desc",
            weight = 0.25f,
            value = 300,
            maxDurability = 1,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/cup_tea.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 20f, waterValue = 60f },
                    new HealData { healValue = 5},
                    new AddBuffData { buff = 1075, chance = 1f },
                    new ReturnItemData { itemTypeID = 131, display = false },
                }
            }
        };

        /// <summary>红茶 — 醇厚温暖，驱散寒意</summary>
        public static ItemData BlackTea => new ItemData
        {
            itemId = 30044,
            order = 34,
            localizationKey = "BlackTea",
            localizationDesc = "BlackTea_Desc",
            weight = 0.25f,
            value = 300,
            maxDurability = 1,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/cup_black_tea.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 30f, waterValue = 50f },
                    new HealData { healValue = 5},
                    new AddBuffData { buff = 2301, chance = 1f },
                    new ReturnItemData { itemTypeID = 131, display = false },
                }
            }
        };

        /// <summary>葡萄汽水 — 老政的秘密爱好，紫色漩涡般的甘甜</summary>
        public static ItemData GrapeSoda => new ItemData
        {
            itemId = 30053,
            order = 35,
            localizationKey = "GrapeSoda",
            localizationDesc = "GrapeSoda_Desc",
            weight = 0.5f,
            value = 600,
            quality = 4,
            maxStackCount = 6,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/grape_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = string.Empty,
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 30f, waterValue = 50f },
                    new HealData { healValue = 5},
                    new AddBuffData { buff = 1113, chance = 1f }
                }
            }
        };

        // ===== 魔蹼能量饮料系列（模仿魔爪，图标为鸭脚蹼） =====

        /// <summary>魔蹼·原味 — 经典能量饮料，撕碎疲惫</summary>
        public static ItemData MonsterWebbingOrigin => new ItemData
        {
            itemId = 30054,
            order = 41,
            localizationKey = "MonsterWebbingOrigin",
            localizationDesc = "MonsterWebbingOrigin_Desc",
            weight = 0.5f,
            value = 450,
            maxDurability = 2,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/monster_webbing_origin.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = string.Empty,
                useTime = 2.0f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 35f, waterValue = 25f },
                    new AddBuffData { buff = 1091, chance = 1f },
                    new AddBuffData { buff = 1093, chance = 1f },
                }
            }
        };

        /// <summary>魔蹼·Pipeline Punch — 热带果味能量饮料，甜美爆发</summary>
        public static ItemData MonsterWebbingPink => new ItemData
        {
            itemId = 30055,
            order = 42,
            localizationKey = "MonsterWebbingPink",
            localizationDesc = "MonsterWebbingPink_Desc",
            weight = 0.5f,
            value = 500,
            maxDurability = 2,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/monster_webbing_pink.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = string.Empty,
                useTime = 2.0f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 35f, waterValue = 25f },
                    new AddBuffData { buff = 1091, chance = 1f },
                    new AddBuffData { buff = 1093, chance = 1f },
                }
            }
        };

        /// <summary>魔蹼·无糖 — 零糖能量饮料，零负担爆发</summary>
        public static ItemData MonsterWebbingWhite => new ItemData
        {
            itemId = 30056,
            order = 43,
            localizationKey = "MonsterWebbingWhite",
            localizationDesc = "MonsterWebbingWhite_Desc",
            weight = 0.5f,
            value = 500,
            maxDurability = 2,
            quality = 4,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            tags = new List<string> { "Food", "Drink" },
            spritePath = "items/monster_webbing_white.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = string.Empty,
                useTime = 2.0f,
                useDurability = true,
                durabilityUsage = 1,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData { energyValue = 30f, waterValue = 30f },
                    new AddBuffData { buff = 1091, chance = 1f },
                    new AddBuffData { buff = 1093, chance = 1f },
                }
            }
        };
    }
}
