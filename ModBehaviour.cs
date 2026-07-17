using Duckov.Modding;
using DuckovDrinks.Building;
using DuckovDrinks.Npc;
using FeatherMod;
using FeatherMod.Items;
using FeatherMod.Utils;
using System.Reflection;
using UnityEngine;

namespace DuckovDrinks
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour, IHasModid
    {
        private string dllPath = Assembly.GetExecutingAssembly().Location;

        public string GetModid() => Constants.MODID;

        protected override void OnAfterSetup()
        {
            // 注册 mod 路径，供 I18n / Sprite 自动解析
            ModPathResolver.Register(GetModid(), dllPath);

            RegisterNpc();
            RegisterBuildings();
            RegisterShop();
            RegisterQuests();
            RegisterItems();
            RegisterCraftingFormulas();
            RegisterDecomposeFormulas();

            // 初始化本地化（自动处理语言切换）
            I18n.InitI18n(GetModid());
            Debug.Log($"{Constants.MODID} awaked, version: {Constants.VERSION}. Presented by Zaia");
        }

        private void RegisterItems()
        {
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_SUANMEITANG), Items.Suanmeitang);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_WHOLE_MILK), Items.WholeMilk);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_ICED_TEA), Items.IcedTea);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_APPLE_MILK), Items.AppleMilk);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_WHITE_SUGAR), Items.WhiteSugar);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_ORANGE_SODA), Items.OrangeSoda);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_SODA_CAN_LEMON), Items.SodaCanLemon);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_SODA_CAN_APPLE), Items.SodaCanApple);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_SODA_CAN_ORANGE), Items.SodaCanOrange);

            // v0.5.0 新增原料
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_COFFEE_BEAN_PACK), Items.CoffeeBeanPack);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_GREEN_TEA_TEABAG), Items.GreenTeaTeabag);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_BLACK_TEA_TEABAG), Items.BlackTeaTeabag);

            // v0.5.0 新增饮品
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_COFFEE_BLACK), Items.CoffeeBlack);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_COFFEE_LATTE), Items.CoffeeLatte);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_GREEN_TEA), Items.GreenTea);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_BLACK_TEA), Items.BlackTea);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_GRAPE_SODA), Items.GrapeSoda);

            // 魔蹼能量饮料系列
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_MONSTER_WEBBING_ORIGIN), Items.MonsterWebbingOrigin);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_MONSTER_WEBBING_PINK), Items.MonsterWebbingPink);
            ItemUtils.CreateCustomItem(Id(Constants.ITEM_MONSTER_WEBBING_WHITE), Items.MonsterWebbingWhite);
        }

        private void RegisterCraftingFormulas()
        {
            GameItemLookup.TryGetIdentifier(14, out var v14);
            GameItemLookup.TryGetIdentifier(106, out var v106);
            GameItemLookup.TryGetIdentifier(107, out var v107);
            GameItemLookup.TryGetIdentifier(115, out var v115);
            GameItemLookup.TryGetIdentifier(131, out var mug);
            GameItemLookup.TryGetIdentifier(428, out var water);
            GameItemLookup.TryGetIdentifier(888, out var apple);
            GameItemLookup.TryGetIdentifier(1256, out var v1256);

            // 酸梅汤: WholeMilk + WhiteSugar → 原版物品(115)
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_suanmeitang"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_WHOLE_MILK), 1),
                    ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 1),
                },
                Result = ItemEntry.Of(v115!, 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 苹果牛奶: WholeMilk + WhiteSugar + 苹果(888) → AppleMilk
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_apple_milk"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_WHOLE_MILK), 1),
                    ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 1),
                    ItemEntry.Of(apple!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_APPLE_MILK), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 柠檬汽水: WhiteSugar + 原版物品(106) → SodaCanLemon
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_lemon_soda"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 1),
                    ItemEntry.Of(v106!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_SODA_CAN_LEMON), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 苹果汽水: 苹果(888) + 原版物品(106) → SodaCanApple
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_apple_soda"),
                CostItems = new[]
                {
                    ItemEntry.Of(apple!, 1),
                    ItemEntry.Of(v106!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_SODA_CAN_APPLE), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 橙子汽水: SodaCanOrange + WhiteSugar + 瓶装水(428) → OrangeSoda
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_orange_soda"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_SODA_CAN_ORANGE), 1),
                    ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 1),
                    ItemEntry.Of(water!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_ORANGE_SODA), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 额外配方: 原版(14) + WhiteSugar*2 + 原版(107) → 原版(1256)
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_extra"),
                CostItems = new[]
                {
                    ItemEntry.Of(v14!, 1),
                    ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 2),
                    ItemEntry.Of(v107!, 1),
                },
                Result = ItemEntry.Of(v1256!, 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // ===== v0.5.0 杯装饮品配方 =====

            // 黑咖啡: 咖啡豆(耐久消耗) + 杯子(131) + 矿泉水(1181) → 黑咖啡
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_coffee_black"),
                CostItems = new[]
                {
                    ItemEntry.ByTag("CoffeeBean", 1).WithDurabilityCost(true),
                    ItemEntry.Of(mug!, 1),
                    ItemEntry.Of(water!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_COFFEE_BLACK), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 拿铁: 咖啡豆(耐久消耗) + 纯牛奶 + 杯子(131) + 矿泉水(1181) → 拿铁
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_coffee_latte"),
                CostItems = new[]
                {
                    ItemEntry.ByTag("CoffeeBean", 1).WithDurabilityCost(true),
                    ItemEntry.Of(Id(Constants.ITEM_WHOLE_MILK), 1),
                    ItemEntry.Of(mug!, 1),
                    ItemEntry.Of(water!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_COFFEE_LATTE), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 绿茶: 茶包 + 杯子(131) + 矿泉水(1181) → 绿茶
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_green_tea"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_GREEN_TEA_TEABAG), 1),
                    ItemEntry.Of(mug!, 1),
                    ItemEntry.Of(water!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_GREEN_TEA), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });

            // 红茶: 茶包 + 杯子(131) + 矿泉水(1181) → 红茶
            CraftingUtils.AddCraftingFormula(new CraftingFormulaData
            {
                Id = Id("recipe_black_tea"),
                CostItems = new[]
                {
                    ItemEntry.Of(Id(Constants.ITEM_BLACK_TEA_TEABAG), 1),
                    ItemEntry.Of(mug!, 1),
                    ItemEntry.Of(water!, 1),
                },
                Result = ItemEntry.Of(Id(Constants.ITEM_BLACK_TEA), 1),
                Tags = new[] { "WorkBenchAdvanced" },
            });
        }

        private void RegisterDecomposeFormulas()
        {
            GameItemLookup.TryGetIdentifier(68, out var v68);
            GameItemLookup.TryGetIdentifier(1181, out var lollipop);

            // 棒棒糖(1181) → 白糖*1
            CraftingUtils.AddDecomposeFormula(new DecomposeFormulaData
            {
                Id = Id("decompose_lollipop"),
                SourceItemId = lollipop!,
                Money = 0,
                ResultItems = new[] { ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 1) },
            });

            // 原版物品(68) → 白糖*2
            CraftingUtils.AddDecomposeFormula(new DecomposeFormulaData
            {
                Id = Id("decompose_item68"),
                SourceItemId = v68!,
                Money = 0,
                ResultItems = new[] { ItemEntry.Of(Id(Constants.ITEM_WHITE_SUGAR), 2) },
            });

            // OrangeSoda → SodaCanOrange*2
            CraftingUtils.AddDecomposeFormula(new DecomposeFormulaData
            {
                Id = Id("decompose_orange_soda"),
                SourceItemId = Id(Constants.ITEM_ORANGE_SODA),
                Money = 0,
                ResultItems = new[] { ItemEntry.Of(Id(Constants.ITEM_SODA_CAN_ORANGE), 2) },
            });
        }

        private static Identifier Id(string path) => new Identifier(Constants.MODID, path);

        private void RegisterBuildings()
        {
            // 饮品制作台：1×2，模型从 AssetBundle "drinks" 加载
            Building.BuildingConfig.Register();
            // 建成回调：生成老政 + 捏脸 + 初次对话
            Building.BuildingConfig.RegisterOnBuiltCallback();
        }

        private void RegisterNpc()
        {
            // 注册 NPC 预设（新版 API：FriendlyNpcUtils.RegisterFriendlyNpc）
            // 实际生成由饮品制作台建成回调触发 BuildConfig.RegisterOnBuiltCallback()
            NpcConfig.Register();
        }

        private void RegisterShop()
        {
            MerchantData.Register();
            MerchantData.RegisterUnlockableGoods();
        }

        private void RegisterQuests()
        {
            QuestConfig.Register();
        }
    }
}
