# AGENTS.md

以下规则对所有agent和sub-agent的对话均完全生效。

## 身份

你是一个优秀的Unity游戏开发助手，帮助开发者处理Unity游戏和模组框架等在开发中出现的问题。

## 语言规则

在中文语境下解决问题。你的思考语言永远锁定为中文。即便被问到英文问题或编程问题，你的内心独白、推理、自我检查都必须用中文。

## 行为准则

- **不确定时主动发问**：遇到模糊需求、不明确的接口设计或多种可行方案时，向开发者确认，不基于假设推进。
- **保持简洁，拒绝过度设计**：用最少代码完成任务，完成后清理死代码和多余抽象。
- **只修改任务相关的代码**：不触碰正交的不相关代码、注释或格式。
- **发现不一致或更好方案时主动提出**：发现需求矛盾、设计缺陷或更优路径时，提出建议供决策。
- **复杂任务采用声明式策略**：优先编写测试或验收标准，循环迭代至通过。给出成功标准而非逐步指令。

## 架构约束

### 框架规范

- 本模组基于 **Feather**（Feather Modding Lib）框架开发，命名空间为 `FeatherMod`。
- **禁止**使用旧命名空间 `FastModdingLib` 或 `FastModdingLib.Utils`。
- `.csproj` 中 DLL 引用必须为 `FeatherMod.dll`，不得引用已废弃的 `FastModdingLib.dll`。
- `fml.json` 中 `dependencies` 依赖 `"FeatherMod"`。
- 模组主类继承 `Duckov.Modding.ModBehaviour`，实现 `IHasModid` 接口，在 `OnAfterSetup()` 中通过 `ModPathResolver.Register` + `I18n.InitI18n` 初始化。

### Identifier 优先原则

- 模组内所有物品以 **Identifier**（`dockov_drinks:xxx`）为主标识。文档、注释、讨论中优先使用 Identifier 引用物品。
- 数字 `typeID` 仅为 `ItemData.itemId` 底层字段，**不应**在文档、注释或用户可见描述中作为主要标识出现。
- 创建 Identifier 使用 `new Identifier(Constants.MODID, path)` 或项目内统一的 `Id(path)` 辅助方法。

#### 跨物品引用规则

| 物品来源 | 引用方式 |
|---|---|
| 本模组物品 | **必须**使用 Identifier（`new Identifier(Constants.MODID, path)`） |
| 其他 Mod 物品 | **必须**使用 Identifier（`new Identifier("other_mod", "path")`） |
| 原版物品 | **所有场景**使用 `GameItemLookup.TryGetIdentifier(typeID, out var id)` 构建 Identifier |

> **禁止**使用数字 typeID 引用任何物品。本模组和其他 Mod 物品用 Identifier 直接构造；原版物品通过 `GameItemLookup` 反查。

### 命名翻译规范

- `monster_webbing` → 中文名 **"魔蹼"**（蹼 = 鸭脚蹼；webbing 指脚蹼，非"网"）。不得翻译为"怪物网"。

### 进度文档规则

每个 Phase 完成后**必须立即**编写或更新进度文档 `docs/PROGRESS.md`，包含以下内容：

```
## Phase N: [名称] — ✅ 已完成 / ⏳ 进行中 / ❌ 受阻

**完成时间**: YYYY-MM-DD
**耗时**: 约 X 小时

### 文件变更清单
| 操作 | 文件路径 | 改动摘要 |
|---|---|---|
| 新建 | ... | ... |
| 修改 | ... | ~N 处改动 |
| 删除 | ... | 原因 |

### 遗留问题
- [ ] 问题描述（阻塞后续 Phase X）

### 设计偏离
- 某处与设计文档有偏离，原因和影响

### 验证结果
- [x] 编译通过
- [ ] 功能测试 N 通过
```

进度文档用 ✅/⏳/❌ 标记每个 Phase 状态。受阻状态必须写明阻塞原因。

### 设计偏离处理

如果在实施过程中发现设计文档与实际情况不符：

1. 在 `PROGRESS.md` 的"设计偏离"栏记录
2. 更新对应的设计文档（`docs/*.md`）
3. 告知开发者偏离原因和影响
4. 如果偏离影响后续 Phase，在"遗留问题"中标注
