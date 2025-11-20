using System;
using System.Collections.Generic;
using System.Text;
using static DuckovDrinks.ItemUtils;

namespace DuckovDrinks
{
    public static class Items
    {
        public static ItemData drink01 = new ItemData
        {
            itemId = 30001,
            order = 11,
            localizationKey = "Suanmeitang",
            localizationDesc = "Suanmeitang_Desc",
            weight = 0.6f,
            value = 400,
            maxDurability = 2,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            tags = { "Food", "Drink" },
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
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 50f
                    }
                }
            }
        };

        public static ItemData drink02 = new ItemData
        {
            itemId = 30002,
            order = 12,
            localizationKey = "WholeMilk",
            localizationDesc = "WholeMilk_Desc",
            weight = 0.26f,
            value = 250,
            quality = 2,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            maxStackCount = 5,
            tags = { "Food", "Drink" },
            spritePath = "items/drink_02.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 2.5f,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 25f
                    }
                }
            }
        };

        public static ItemData drink03 = new ItemData
        {
            itemId = 30003,
            order = 13,
            localizationKey = "IcedTea",
            localizationDesc = "IcedTea_Desc",
            weight = 0.6f,
            value = 600,
            maxDurability = 2,
            quality = 4,
            tags = { "Food", "Drink" },
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
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
                    new FoodData
                    {
                        energyValue = 25f,
                        waterValue = 50f
                    }
                }
            }
        };

        public static ItemData drink04 = new ItemData
        {
            itemId = 30004,
            order = 12,
            localizationKey = "AppleMilk",
            localizationDesc = "AppleMilk_Desc",
            weight = 0.5f,
            value = 650,
            maxDurability = 2,
            quality = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Green,
            tags = { "Food", "Drink" },
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
                    new FoodData
                    {
                        energyValue = 30f,
                        waterValue = 45f
                    }
                }
            }
        };

        public static ItemData WhiteSugar = new ItemData
        {
            itemId = 30005,
            order = 12,
            localizationKey = "WhiteSugar",
            localizationDesc = "WhiteSugar_Desc",
            weight = 0.5f,
            value = 100,
            quality = 1,
            displayQuality = ItemStatsSystem.DisplayQuality.White,
            tags = { "Food"},
            spritePath = "items/white_sugar.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_food",
                useSound = string.Empty,
                useTime = 2.5f,
                useDurability = false,
                behaviors = new List<UsageBehaviorData>
            {
                new FoodData
                {
                    energyValue = 25f,
                    waterValue = -50f
                }
            }
            }
        };

        public static ItemData drink05 = new ItemData
        {
            itemId = 30006,
            order = 21,
            localizationKey = "OrangeSoda",
            localizationDesc = "OrangeSoda_Desc",
            weight = 0.8f,
            value = 650,
            maxDurability = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            quality = 5,
            tags = { "Food", "Drink" },
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
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 35f
                    },
                    new AddBuffData{
                        buff = 1101,
                        chance = 1F
                    }
                }
            }
        };

        public static ItemData sodaCanLemon = new ItemData
        {
            itemId = 30007,
            order = 21,
            localizationKey = "SodaCanLemon",
            localizationDesc = "SodaCanLemon_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            quality = 4,
            tags = { "Food", "Drink" },
            spritePath = "items/lemon_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                useDurability = false,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 35f
                    },
                    new AddBuffData{
                        buff = 1101,
                        chance = 1F
                    }
                }
            }
        };

        public static ItemData sodaCanApple = new ItemData
        {
            itemId = 30008,
            order = 21,
            localizationKey = "SodaCanApple",
            localizationDesc = "SodaCanApple_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            quality = 4,
            tags = { "Food", "Drink" },
            spritePath = "items/apple_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                useDurability = false,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 35f
                    },
                    new AddBuffData{
                        buff = 1101,
                        chance = 1F
                    }
                }
            }
        };

        public static ItemData sodaCanOrange = new ItemData
        {
            itemId = 30009,
            order = 21,
            localizationKey = "SodaCanOrange",
            localizationDesc = "SodaCanOrange_Desc",
            weight = 0.4f,
            value = 450,
            maxStackCount = 3,
            displayQuality = ItemStatsSystem.DisplayQuality.Blue,
            quality = 4,
            tags = { "Food", "Drink" },
            spritePath = "items/orange_soda_can.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_cola",
                useSound = "SFX/Item/use_cola_success",
                useTime = 2.5f,
                useDurability = false,
                behaviors = new List<UsageBehaviorData>
                {
                    new FoodData
                    {
                        energyValue = 20f,
                        waterValue = 35f
                    },
                    new AddBuffData{
                        buff = 1101,
                        chance = 1F
                    }
                }
            }
        };
    }
}
