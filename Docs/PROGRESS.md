# Duckov Drinks 开发进度

## Phase: Feather 框架迁移 + v0.5.0 物品扩充 — ✅ 已完成

**完成时间**: 2026-07-16
**耗时**: 约 0.5 小时

### 变更摘要

#### 框架迁移（FastModdingLib → Feather）
| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 修改 | `DuckovDrinks.csproj` | DLL 引用 `FastModdingLib.dll` → `FeatherMod.dll` |
| 修改 | `ModBehaviour.cs` | `using FastModdingLib` → `using FeatherMod`；`using FastModdingLib.Utils` → `using FeatherMod.Utils` |
| 修改 | `Items.cs` | `using FastModdingLib` → `using FeatherMod` |

#### 新增物品
| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 修改 | `Constants.cs` | 新增 8 个物品 Identifier path 常量 |
| 修改 | `Items.cs` | 新增 8 个 ItemData 静态属性 |
| 修改 | `ModBehaviour.cs` | RegisterItems() 中新增 8 个物品注册调用 |
| 修改 | `assets/lang/zh_cn.json` | 新增 8 个物品的本地化条目 |

### 新增物品清单

| Identifier | 名称 | 纹理 | 品质 |
|---|---|---|---|
| `dockov_drinks:coffee_black` | 黑咖啡 | cup_coffee.png | Green |
| `dockov_drinks:coffee_latte` | 拿铁 | cup_latte.png | Blue |
| `dockov_drinks:green_tea` | 绿茶 | cup_tea.png | Green |
| `dockov_drinks:black_tea` | 红茶 | cup_black_tea.png | Green |
| `dockov_drinks:grape_soda` | 葡萄汽水 | grape_soda_can.png | Blue |
| `dockov_drinks:monster_webbing_origin` | 魔蹼·原味 | monster_webbing_origin.png | Green |
| `dockov_drinks:monster_webbing_pink` | 魔蹼·Pipeline Punch | monster_webbing_pink.png | Blue |
| `dockov_drinks:monster_webbing_white` | 魔蹼·无糖 | monster_webbing_white.png | Blue |

### 新增纹理文件（用户手动添加）
- `cup_coffee.png`, `cup_latte.png`, `cup_tea.png`, `cup_black_tea.png`
- `grape_soda_can.png`
- `monster_webbing_origin.png`, `monster_webbing_pink.png`, `monster_webbing_white.png`

### 遗留问题
- [ ] 新增饮品暂无合成配方（预留后续 Phase）
- [ ] `en_us.json` / `zh_tw.json` 未同步更新英文和繁中本地化
- [ ] 未添加编译验证（C# LSP 不可用，需在 Unity/VS 中手动编译确认）

### 设计偏离
- 魔蹼系列为 PLAN_v0.5.0 之外的新增物品，暂不影响规划内容

---

## Phase: NPC 老政 — ✅ 已完成

**完成时间**: 2026-07-16

### 变更摘要

| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 新建 | `assets/npc/laozheng_face.json` | 老政捏脸数据 |
| 新建 | `Npc/NpcConfig.cs` | NPC 配置类（Identifier、`CustomFaceUtils` 捏脸加载） |
| 修改 | `ModBehaviour.cs` | 新增 `RegisterNpc()`（由建筑建成回调触发实际生成） |
| 修改 | `Constants.cs` | 新增 `NPC_LAOZHENG` 常量 |
| 修改 | `assets/lang/zh_cn.json` | 新增 `npc_laozheng_name` |

### NPC 数据

| 字段 | 值 |
|---|---|
| Identifier | `dockov_drinks:npc_laozheng` |
| 角色 | `NpcRole.Merchant` |
| ActorId | `laozheng` |
| 捏脸 | `assets/npc/laozheng_face.json` → `CustomFaceUtils.SetFaceFromJson` |

### 遗留问题
- [ ] 老政不由 Init 阶段直接生成——由饮品制作台建成回调触发
- [ ] 商店（ShopId）和任务（QuestGiverId）尚未接入

---

## Phase: 饮品制作台 + NPC 建成回调 — ✅ 已完成

**完成时间**: 2026-07-16

### 变更摘要

| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 修改 | `Npc/NpcConfig.cs` | 重构：`FaceRef` → `CustomFaceUtils`；`CreateConfig` 接受 `Vector3`；新增 `ApplyFace` |
| 新建 | `Building/BuildingConfig.cs` | 饮品站注册 + 建成回调（生成 NPC + 捏脸 + 对话） |
| 修改 | `ModBehaviour.cs` | 新增 `RegisterBuildings()` |
| 修改 | `Constants.cs` | 新增 `BUILDING_DRINK_STATION` |
| 修改 | `assets/lang/zh_cn.json` | 新增建筑名称和描述 |

### 饮品制作台

| 属性 | 值 |
|---|---|
| Identifier | `dockov_drinks:building_drink_station` |
| 占地 | 1×2 |
| 模型 | AssetBundle `drinks` → `DrinkStation` |
| 造价 | 3000 金钱 |
| 建成回调 | 建筑右侧生成老政 → 应用捏脸 → 播放初次对话 |

### 初次对话（占位，走本地化 I18n）

| TextKey | 中文 |
|---|---|
| `dialogue_laozheng_greet_1` | 哟，终于有人来了。 |
| `dialogue_laozheng_greet_2` | 我是老政，以前在零号区南边开饮品铺的。 |
| `dialogue_laozheng_greet_3` | 铺子被风暴怪物砸了，只好来这儿混口饭吃。 |
| `dialogue_laozheng_greet_4` | 你这儿……有水吗？没水可做不了饮品。 |

### 遗留问题
- [ ] 建筑解锁条件（应由杰夫任务奖励图纸，当前直接可用）
- [ ] 饮品台交互面板（配方制作 UI）未实现
- [ ] 服装 ID32 尚未装备（需确认 Feather API 或游戏原生装备系统）

---

## Phase: 商人商店 + 任务 — ✅ 已完成

**完成时间**: 2026-07-16

### 变更摘要

| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 修改 | `Npc/NpcConfig.cs` | 新增 `MerchantProfileId` / `QuestGiverId` 常量，`CreateConfig` 绑定 |
| 新建 | `Npc/MerchantData.cs` | 商人 Profile + 基础商品 + 可解锁商品 |
| 新建 | `Npc/QuestConfig.cs` | 任务 "安顿下来"：提交物品 → 解锁苹果/橘子购买 |
| 修改 | `ModBehaviour.cs` | 新增 `RegisterShop()` + `RegisterQuests()` |
| 修改 | `Constants.cs` | 新增 `QUEST_LAOZHENG_SETTLE` |
| 修改 | `assets/lang/zh_cn.json` | 新增任务名和描述 |
| 修改 | `Building/BuildingConfig.cs` | 服装 ID32 TODO |

### 商人商店

| 商品 | 来源 | 库存 | 价格倍率 | 解锁 |
|---|---|---|---|---|
| 白砂糖 (30005) | 本模组 | 10 | 1.0 | 初始 |
| 纯牛奶 (30002) | 本模组 | 5 | 1.0 | 初始 |
| 瓶装水 (1181) | 原版 | 8 | 1.2 | 初始 |
| 苹果 (888) | 原版 | 5 | 1.0 | 任务 |
| 橘子 (1011) | 原版 | 5 | 1.0 | 任务 |

### 任务 "安顿下来"

| 属性 | 值 |
|---|---|
| Identifier | `dockov_drinks:quest_laozheng_settle` |
| QuestGiver | 老政（`QuestGiverIdentifier = dockov_drinks:laozheng`） |
| 需求 | 白砂糖 ×3 + 纯牛奶 ×2 |
| 奖励 | 金钱 1000 + 解锁苹果购买 + 解锁橘子购买 |

### 遗留问题
- [ ] `RewardUnlockItem.typeID` 字段是否有效（文档标注 `itemIdentifier`，待编译确认）
- [ ] 任务奖励仅解锁商品，配方解锁需后续 Phase 实现
- [ ] 服装 ID32 装备方式待确认

---

## Phase: 原料 + 杯装饮品配方 — ✅ 已完成

**完成时间**: 2026-07-16

### 变更摘要

| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 修改 | `Items.cs` | 新增咖啡豆袋、绿茶茶包、红茶茶包；4 种杯装饮品添加 `ReturnItemData(131)` |
| 修改 | `Constants.cs` | 新增 3 个原料常量 |
| 修改 | `ModBehaviour.cs` | 注册 3 个原料 + 4 个杯装饮品配方（耐久消耗机制） |
| 修改 | `assets/lang/zh_cn.json` | 新增原料本地化 |

### 新增原料

| Identifier | 名称 | typeID | 耐久 | 标签 | 纹理 |
|---|---|---|---|---|---|
| `dockov_drinks:coffee_bean_pack` | 咖啡豆（袋装） | 30012 | 25 | CoffeeBean | coffee_bean_pack.png |
| `dockov_drinks:green_tea_teabag` | 绿茶茶包 | 30013 | 10 | TeaBag | green_tea_teabag.png |
| `dockov_drinks:black_tea_teabag` | 红茶茶包 | 30014 | 10 | TeaBag | black_tea_teabag.png |

### 杯装饮品配方

| 配方 ID | 原料 | 产出 | 机制 |
|---|---|---|---|
| `recipe_coffee_black` | CoffeeBean(耐久消耗) + 杯子(131) + 矿泉水(1181) | 黑咖啡(30041) | `ByTag.WithDurabilityCost` |
| `recipe_coffee_latte` | CoffeeBean(耐久消耗) + 纯牛奶(30002) + 杯子(131) + 矿泉水(1181) | 拿铁(30042) | `ByTag.WithDurabilityCost` |
| `recipe_green_tea` | TeaBag(耐久消耗) + 杯子(131) + 矿泉水(1181) | 绿茶(30043) | `ByTag.WithDurabilityCost` |
| `recipe_black_tea` | TeaBag(耐久消耗) + 杯子(131) + 矿泉水(1181) | 红茶(30044) | `ByTag.WithDurabilityCost` |

### 耐久消耗机制

- 咖啡豆袋 `maxDurability=25`（500g÷20g/杯），每次合成消耗 1 点耐久
- 茶包 `maxDurability=10`（10 包/盒），每次合成消耗 1 点
- 配方中使用 `ItemEntry.ByTag("CoffeeBean"/"TeaBag", 1).WithDurabilityCost(true)`
- 满耐久物品 = 1 个，50% 耐久 = 0.5 个

### 杯子返还

- 黑咖啡/拿铁/绿茶/红茶饮用后通过 `ReturnItemData { itemTypeID = 131 }` 返还杯子
