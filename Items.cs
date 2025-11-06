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
            //CodeName = "Drink01",
            order = 11,
            displayName = "酸梅汤",
            localizationKey = "Drink01",
            localizationDesc = "Drink01_Desc",
            localizationDescValue = "夏日传统解暑饮品。",
            weight = 0.6f,
            value = 400,
            maxDurability = 2,
            quality = 0,
            tags = { "Food", "Drink" },
            embeddedSpritePath = "items/drink_01.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 1.5f,
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
            //CodeName = "Drink01",
            order = 12,
            displayName = "纯牛奶",
            localizationKey = "Drink02",
            localizationDesc = "Drink02_Desc",
            localizationDescValue = "全脂纯牛奶，乳糖不耐受的要注意。",
            weight = 0.26f,
            value = 250,
            quality = 0,
            maxStackCount = 5,
            tags = { "Food", "Drink" },
            embeddedSpritePath = "items/drink_02.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 1.5f,
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
            displayName = "冰红茶",
            localizationKey = "Drink03",
            localizationDesc = "Drink03_Desc",
            localizationDescValue = "在鸭星也非常出名的冰红茶。",
            weight = 0.6f,
            value = 600,
            maxDurability = 2,
            quality = 1,
            tags = { "Food", "Drink" },
            embeddedSpritePath = "items/iced_tea.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 1.5f,
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
            //CodeName = "Drink01",
            order = 12,
            displayName = "营养快线",
            localizationKey = "Drink04",
            localizationDesc = "Drink04_Desc",
            localizationDescValue = "苹果风味牛奶。",
            weight = 0.5f,
            value = 650,
            maxDurability = 2,
            quality = 1,
            tags = { "Food", "Drink" },
            embeddedSpritePath = "items/apple_milk.png",
            usages = new UsageData
            {
                actionSound = "SFX/Item/use_drink",
                useSound = string.Empty,
                useTime = 1.5f,
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
    }
}
